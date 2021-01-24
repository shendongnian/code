public async void SetLocationAsClientAddress()
        {
            Client client = Client;
            Address clientsAddress;
            if (client != null)
            {
                clientsAddress = await Database.GetAddressFor(client);
                // Location is a property in the ViewModel, as well as an object type
                Location = new Location(0, clientsAddress.StreetNumber, clientsAddress.StreetName, clientsAddress.Suburb, clientsAddress.Postcode);
            }
        }
This way the PropertyChanged event knows that the ViewModel property, which is an object, is different, and lets the View know.
