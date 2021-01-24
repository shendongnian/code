    var communicator = new Communicator();
    var manager = new CommunicationManager(communicator);
    var vm = new SystemViewModel( manager );
    vm.PropertyChanged += (s,e) => Console.WriteLine( "SystemViewModel.{0} changed", e.PropertyName );
    communicator.Connected = true;
    communicator.Connected = false;
