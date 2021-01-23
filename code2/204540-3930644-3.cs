    public interface IChannel<TMessage>
    {
        // Methods
        TMessage Receive();
        void Send(TMessage message);
    
        // Properties
        bool CanReceive { get; }
        bool CanSend { get; }
        ChannelState State { get; }
    }
    using System;
    public interface IReceiver<TMessage>
    {
        // Events
        event EventHandler<MessageReceivedEventArgs<TMessage>> MessageReceived;
    
        // Methods
        void Activate();
        void Deactivate();
    
        // Properties
        bool IsActive { get; }
    }
