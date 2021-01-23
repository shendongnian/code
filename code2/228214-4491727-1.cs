    public void GoThrough(List<object> myList)
    {
        foreach (object item in myList)
        {
            MessageBox.Show(item.ToString());
        }
    }
