    // ... in remote facade or client code ...
    var orderActivationCommand = new OrderActivationCommand(orderID);
    _commandService.ExecuteCommand(orderActivationCommand);
    // ... in application layer (service) ...
    public void ExecuteCommand(Command command)
    {
        _commandExeuter.Execute(command);
    }
