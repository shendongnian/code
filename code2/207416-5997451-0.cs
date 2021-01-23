    using (XServiceSoapClient client = new XServiceSoapClient())
    {
       client.State;
    }
    public enum CommunicationState
    {
        // Summary:
        //     Indicates that the communication object has been instantiated and is configurable,
        //     but not yet open or ready for use.
        Created = 0,
        //
        // Summary:
        //     Indicates that the communication object is being transitioned from the System.ServiceModel.CommunicationState.Created
        //     state to the System.ServiceModel.CommunicationState.Opened state.
        Opening = 1,
        //
        // Summary:
        //     Indicates that the communication object is now open and ready to be used.
        Opened = 2,
        //
        // Summary:
        //     Indicates that the communication object is transitioning to the System.ServiceModel.CommunicationState.Closed
        //     state.
        Closing = 3,
        //
        // Summary:
        //     Indicates that the communication object has been closed and is no longer
        //     usable.
        Closed = 4,
        //
        // Summary:
        //     Indicates that the communication object has encountered an error or fault
        //     from which it cannot recover and from which it is no longer usable.
        Faulted = 5,
    }
