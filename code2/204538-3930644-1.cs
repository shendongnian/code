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
