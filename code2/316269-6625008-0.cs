    public void LogEmployees (IEnumerable<dynamic> list)
    {
        foreach (dynamic item in list)
        {
            string name = item.Name;
            int id = item.Id;
        }
    }
