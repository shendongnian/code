     private Client newClientRow()
        {
            var clients = new ObservableCollection<Client>();
            var client = new Client
            {
                clientID = -1,
                clientName = "New Client",
                clientEmail = "f",
                add1 = "f",
                add2 = "R",
                add3 = "l",
                add4 = "F",
                postcode = "f",
                telephoneNumber = "01244"
            };
            return client;
        }
