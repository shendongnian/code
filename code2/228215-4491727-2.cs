    public void GoThrough(IEnumerable myEnumerable)
    {
        foreach (object obj in myEnumerable)
        {
            MessageBox.Show(obj.ToString());
        }
    }
