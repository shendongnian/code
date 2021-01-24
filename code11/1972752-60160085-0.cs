    public class SystemViewModel : ReactiveObject
    {
        private readonly CommunicationManager communicationManager;
        private readonly ObservableAsPropertyHelper<string> connectionStatus;
        public SystemViewModel( CommunicationManager communicationManager )
        {
            this.communicationManager = communicationManager ?? throw new ArgumentNullException(nameof(communicationManager));
            this.communicationManager
                .WhenAnyValue( e => e.YepConnected, state => state ? "Green" : "Red" )
                .ToProperty( this, e => e.ConnectionStatus, out connectionStatus );
        }
        public string ConnectionStatus => connectionStatus.Value;
    }
---
    public class CommunicationManager : ReactiveObject
    {
        private readonly Communicator communicator;
        private readonly ObservableAsPropertyHelper<bool> yepConnected;
        public CommunicationManager(Communicator communicator)
        {
            this.communicator = communicator ?? throw new ArgumentNullException(nameof(communicator));
            this.communicator
                .WhenAnyValue( e => e.Connected )
                .ToProperty( this, e => e.YepConnected, out yepConnected );
        }
        public bool YepConnected => yepConnected.Value;
    }
