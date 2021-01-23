    private void downButton_Click(object sender, EventArgs e)
    {
        string NameSet = (sender as Button).Name.Split(new char[] { '_' })[1];
        int itemNo = Int32.Parse(NameSet);
        if (itemNo>0)
        {
           //swap row locations
           var temp = _myControls[itemNo-1].Y;
           _myControls[itemNo-1].Y = _myControls[itemNo].Y;
           _myControls[itemNo].Y = temp;
           //swap list order
           var tempObj = _myControls[itemNo];
           _myControls.RemoveAt(itemNo);
           _myControls.Insert(tempObj, itemNo-1);
        }
    }
