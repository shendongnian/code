    public void ActivateOrder(int orderID)
    {
        var order = _orderRepository.FindOrder(orderID);
        order.Activate();
    }
    public void UpdateClientAddress(ClientAddressDTO address)
    {
        var client = _clientRepository.FindClient(address.ClientID);
        client.Address = // .. map ClientAddressDTO to Address
    }
