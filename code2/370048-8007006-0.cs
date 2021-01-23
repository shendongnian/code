        ...
        BulletedList ul = new BulletedList();
        ul.ID = "paginationDyn";
        ul.DisplayMode = BulletedListDisplayMode.LinkButton;
        ul.Click += new BulletedListEventHandler(ul_Click);
    }
    void ul_Click(object sender, BulletedListEventArgs e)
    {
        throw new NotImplementedException();
    }
