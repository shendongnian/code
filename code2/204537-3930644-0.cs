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
