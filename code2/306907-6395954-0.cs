    if (a.Connections.Count > 0)
    {
         var newList = new List<IEmpConnection>(a.Connections);
         a.Connections.RemoveAt(1);
         a.Connections = newList;
    } 
