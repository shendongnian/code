    public void ActivateOrder(int orderID)
    {
        var orderActivationCommand = new OrderActivationCommand(orderID);
        _commandExecuter.Execute(orderActivationCommand);
    }
    public void UpdateClientAddress(ClientAddressDTO address)
    {
        var clientMovingCommand = new clientMovingCommand(address.ClientID, address.PostalCode, ...);
        _commandExecuter.Execute(clientMovingCommand);
    }
