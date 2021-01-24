    string search = "A";
    string replace = "B";
    for(int i = 0; i < lb1.Items.Count; i++)
    {
        if(lb1.Items[i].ToString().EndsWith(search))
        {
            string item = lb1.Items[i].ToString().Replace(search, replace);
            lb1.Items[i] = item;
        }
    }
