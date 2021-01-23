    string listCount = blistselected.Items.Count;
    string[] array = new string[listCount];
    for (int i=0; i<blistselected.Items.Count; i++) 
    {
        array[i] = blistselected.Items[i].Text;
    }
