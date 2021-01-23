    public Stream GetSomeObject(int groupId)
    {
        byte[] bytes;
        var serializer = new JsonSerializer();
        switch(groupId)
        {
            case 2:
                var groups = GetGroups(); // fill the groups however
                bytes = Encoding.UTF8.GetBytes(serializer.Serialize(groups));
                break;
            case 3:
                var customers = GetCustomers();
                bytes = Encoding.UTF8.GetBytes(serializer.Serialize(customers));
                break;
        }
        return new MemoryStream(bytes);
    }
