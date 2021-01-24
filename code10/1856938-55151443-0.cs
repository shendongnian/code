    foreach (DataRow r in dtData.Rows)
    {
        if (r.Item["SS"] == DateTime.Now.ToString("MMMM"))
        {
            Console.WriteLine(r.Item["CN"] + r.Item["SS"]);
        }
    }
