    if (a.Connections.Count > 0)
    {
        /// REMOVE THIS LINE a.Connections = new List<IEmpConnection>();
        a.Connections.RemoveAt(1);// this item is not being removed.
    }
