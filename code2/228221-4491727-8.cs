    public void GoThrough(IEnumerable myEnumerable)
    {
        IEnumerator myEnumerator = myEnumerable.GetEnumerator();
        while (myEnumerator.MoveNext())
        {
            MessageBox.Show(myEnumerator.Current.ToString());
        }
    }
