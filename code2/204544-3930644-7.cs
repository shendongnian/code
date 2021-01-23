    using System.Collections.Generic;
    using System.Threading;
    using System;
    public class BufferedChannel<TMessage> : IChannel<TMessage>
    {
        // Fields
        private int _blockedReceivers;
        private int _blockedSenders;
        private Queue<TMessage> _buffer;
        private int _capacity;
        private EventWaitHandle _capacityAvailableEvent;
        private EventWaitHandle _messagesAvailableEvent;
    
        // Methods
        public BufferedChannel()
        {
            this._buffer = new Queue<TMessage>();
            this._messagesAvailableEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            this._capacityAvailableEvent = new EventWaitHandle(true, EventResetMode.AutoReset);
            this._capacity = 50;
        }
    
        public BufferedChannel(int bufferSize)
        {
            this._buffer = new Queue<TMessage>();
            this._messagesAvailableEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            this._capacityAvailableEvent = new EventWaitHandle(true, EventResetMode.AutoReset);
            this._capacity = 50;
            if (bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize", bufferSize, ExceptionMessages.ChannelsBufferSizeMustBeGreaterThanZero);
            }
            this._capacity = bufferSize;
        }
    
        public TMessage Receive()
        {
            Interlocked.Increment(ref this._blockedReceivers);
            try
            {
                this._messagesAvailableEvent.WaitOne();
            }
            catch
            {
                lock (this._buffer)
                {
                    Interlocked.Decrement(ref this._blockedReceivers);
                }
                throw;
            }
            lock (this._buffer)
            {
                Interlocked.Decrement(ref this._blockedReceivers);
                this._capacityAvailableEvent.Set();
                if ((this._buffer.Count - 1) > this._blockedReceivers)
                {
                    this._messagesAvailableEvent.Set();
                }
                return this._buffer.Dequeue();
            }
        }
    
        public void Send(TMessage message)
        {
            Interlocked.Increment(ref this._blockedSenders);
            try
            {
                this._capacityAvailableEvent.WaitOne();
            }
            catch
            {
                lock (this._buffer)
                {
                    Interlocked.Decrement(ref this._blockedSenders);
                }
                throw;
            }
            lock (this._buffer)
            {
                Interlocked.Decrement(ref this._blockedSenders);
                this._buffer.Enqueue(message);
                if (this._buffer.Count < this.BufferSize)
                {
                    this._capacityAvailableEvent.Set();
                }
                this._messagesAvailableEvent.Set();
            }
        }
    
        // Properties
        public int BufferCount
        {
            get
            {
                lock (this._buffer)
                {
                    return this._buffer.Count;
                }
            }
        }
    
        public int BufferSize
        {
            get
            {
                lock (this._buffer)
                {
                    return this._capacity;
                }
            }
            set
            {
                lock (this._buffer)
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("BufferSize", value, ExceptionMessages.ChannelsBufferSizeMustBeGreaterThanZero);
                    }
                    this._capacity = value;
                    if ((this._blockedSenders > 0) && (this._capacity > this._buffer.Count))
                    {
                        this._capacityAvailableEvent.Set();
                    }
                }
            }
        }
    
        public bool CanReceive
        {
            get
            {
                return true;
            }
        }
    
        public bool CanSend
        {
            get
            {
                return true;
            }
        }
    
        public ChannelState State
        {
            get
            {
                if (this._blockedSenders > 0)
                {
                    return ChannelState.WaitingForReceive;
                }
                if (this._blockedReceivers > 0)
                {
                    return ChannelState.WaitingForSend;
                }
                return ChannelState.Open;
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    public sealed class Receiver<TMessage> : Component, IReceiver<TMessage>
    {
        // Fields
        private volatile bool _continue;
        private object _controlLock;
        private volatile bool _disposed;
        private Thread _receiverThread;
        private bool _receiving;
        private object _receivingLock;
        private object _threadLock;
        [CompilerGenerated]
        private IChannel<TMessage> channel;
    
        // Events
        public event EventHandler<MessageReceivedEventArgs<TMessage>> MessageReceived;
    
        // Methods
        public Receiver(IChannel<TMessage> channel)
        {
            this._controlLock = new object();
            this._threadLock = new object();
            this._receivingLock = new object();
            if (channel == null)
            {
                throw new ArgumentNullException("channel");
            }
            this.Channel = channel;
        }
    
        public void Activate()
        {
            this.CheckDisposed();
            lock (this._controlLock)
            {
                if (this._receiverThread != null)
                {
                    throw new InvalidOperationException();
                }
                this._continue = true;
                this._receiverThread = new Thread(new ThreadStart(this.RunAsync));
                this._receiverThread.IsBackground = true;
                this._receiverThread.Start();
            }
        }
    
        private void CheckDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(base.GetType().Name);
            }
        }
    
        public void Deactivate()
        {
            lock (this._controlLock)
            {
                if (this._continue)
                {
                    this._continue = false;
                    lock (this._threadLock)
                    {
                        if (this._receiverThread != null)
                        {
                            this.SafeInterrupt();
                            this._receiverThread.Join();
                            this._receiverThread = null;
                        }
                    }
                }
            }
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this.Deactivate();
                this._disposed = true;
            }
        }
    
        private void OnMessageReceived(TMessage message)
        {
            EventHandler<MessageReceivedEventArgs<TMessage>> messageReceived = this.MessageReceived;
            if (messageReceived != null)
            {
                messageReceived(this, new MessageReceivedEventArgs<TMessage>(message));
            }
        }
    
        private void RunAsync()
        {
            while (this._continue)
            {
                TMessage message = default(TMessage);
                bool flag = false;
                try
                {
                    lock (this._receivingLock)
                    {
                        this._receiving = true;
                    }
                    message = this.Channel.Receive();
                    flag = true;
                    lock (this._receivingLock)
                    {
                        this._receiving = false;
                    }
                    Thread.Sleep(0);
                }
                catch (ThreadInterruptedException)
                {
                }
                if (!this._continue)
                {
                    if (flag)
                    {
                        this.Channel.Send(message);
                        return;
                    }
                    break;
                }
                this.OnMessageReceived(message);
            }
        }
    
        private void SafeInterrupt()
        {
            lock (this._receivingLock)
            {
                lock (this._threadLock)
                {
                    if (this._receiving && (this._receiverThread != null))
                    {
                        this._receiverThread.Interrupt();
                    }
                }
            }
        }
    
        // Properties
        protected override bool CanRaiseEvents
        {
            get
            {
                return true;
            }
        }
    
        public IChannel<TMessage> Channel
        {
            [CompilerGenerated]
            get
            {
                return this.channel;
            }
            [CompilerGenerated]
            private set
            {
                this.channel = value;
            }
        }
    
        public bool IsActive
        {
            get
            {
                lock (this._controlLock)
                {
                    return (this._receiverThread != null);
                }
            }
        }
    }
    using System;
    using System.Runtime.CompilerServices;
    public class MessageReceivedEventArgs<TMessage> : EventArgs
    {
        // Fields
        [CompilerGenerated]
        private TMessage message;
    
        // Methods
        public MessageReceivedEventArgs(TMessage message)
        {
            this.Message = message;
        }
    
        // Properties
        public TMessage Message
        {
            [CompilerGenerated]
            get
            {
                return this.message;
            }
            [CompilerGenerated]
            private set
            {
                this.message = value;
            }
        }
    }
    using System.Threading;
    public class BlockingChannel<TMessage> : IChannel<TMessage>
    {
        // Fields
        private TMessage _message;
        private EventWaitHandle _messageReceiveEvent;
        private EventWaitHandle _messageReceiveyEvent;
        private object _sendLock;
        private ChannelState _state;
        private object _stateLock;
    
        // Methods
        public BlockingChannel()
        {
            this._state = ChannelState.Open;
            this._stateLock = new object();
            this._messageReceiveyEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            this._messageReceiveEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            this._sendLock = new object();
        }
    
        public TMessage Receive()
        {
            this.State = ChannelState.WaitingForSend;
            this._messageReceiveyEvent.WaitOne();
            this._messageReceiveEvent.Set();
            this.State = ChannelState.Open;
            return this._message;
        }
    
        public void Send(TMessage message)
        {
            lock (this._sendLock)
            {
                this._message = message;
                this.State = ChannelState.WaitingForReceive;
                this._messageReceiveyEvent.Set();
                this._messageReceiveEvent.WaitOne();
            }
        }
    
        // Properties
        public bool CanReceive
        {
            get
            {
                return true;
            }
        }
    
        public bool CanSend
        {
            get
            {
                return true;
            }
        }
    
        public ChannelState State
        {
            get
            {
                lock (this._stateLock)
                {
                    return this._state;
                }
            }
            private set
            {
                lock (this._stateLock)
                {
                    this._state = value;
                }
            }
        }
    }
