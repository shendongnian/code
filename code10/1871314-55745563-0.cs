    void FillParentListView(List<Parent> parents)
    {
        foreach(Parent p in parents)
        {
            listview.Items.Add(p);
            foreach(Child c in p.ChildList)
                listview.Items.Add(c);
        }
    }
