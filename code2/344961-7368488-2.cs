    var connection = Dts.Connections.Cast<ConnectionManager>()
                                    .First(cm => cm.Name == "m");
    var property = connection.Properties.Cast<DtsProperty>()
                                        .Single(p => p.Name == "Initial Catalog");
    property.SetValue(connection, "some value");
