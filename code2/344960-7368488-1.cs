    for (int i = 0; i < Dts.Connections.Count; i++)
    {
        var connection = Dts.Connections[i];
        if (connection.Name == "m")
        {
            for (int j = 0; j < connection.Properties.Count; j++)
            {
                var property = connection.Properties[j];
    
                if (property.Name == "Initial Catalog")
                    property.SetValue(connection, "some value");
            }
        }
    }
