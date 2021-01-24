    var clients = new List<Client>
    {
        new Client() { ID = 1, FirstName = "Tom", LastName = "Saver", ClientID = 1590 },
        new Client() { ID = 2, FirstName = "John", LastName = "Saver", ClientID = 1590 },
        new Client() { ID = 3, FirstName = "Help", LastName = "Desk", ClientID = 0 },
        new Client() { ID = 4, FirstName = "Tom", LastName = "Saver", ClientID = 0 },
        new Client() { ID = 5, FirstName = "Hello", LastName = "World", ClientID = 1590 }
    };
    var groupByFullName = clients.GroupBy(x => string.Concat(x.FirstName, " ", x.LastName));
