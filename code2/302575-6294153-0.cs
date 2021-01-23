    List<string> titles = new List<string>();
    using (IDataReader test = ((IDataReader)(DataProvider.Instance().ExecuteReader("fetchtest"))))
    {
        while (test.Read())
        {
           titles.Add(test.GetString(0));
        }
    }
    
    
    title1.Text = titles[0];
    title2.Text = titles[1];
    title3.Text = titles[2];
    title4.Text = titles[3];
