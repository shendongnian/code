    public void GoThrough(List<object> myList)
    {
        for (int i=0; i<myList.Count; i++)
        {
            MessageBox.Show(myList[i].ToString());
        }
    }
