    string[] GetTexBoxNames()
    {
        var names =new List<string>();
        for each(var c in this.Controls)
        {
            if(c is TextBox)
            {
                names.Add(c.name);
            }
        }
        return names.ToArray();
    }
