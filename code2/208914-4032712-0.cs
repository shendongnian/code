     List<ClientEntity> clientList = new List<ClientEntity>();
    var returnList = (from PersonsInChargeEntity pic in picList
                     join ClientEntity client in clientList
                     on pic.ClientNumber equals client.ClientNumber
                     select pic ;
