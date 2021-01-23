    private void QuickSearch(string item)
    {
        DL.DLQuickSerch qc = new DL.DLQuickSerch(item);
        List<Common.CommonPersonSerchResult> reslt = qc.GetQuickSerchResult();
        FillListView(reslt);
    } 
 
    private void FillListView(List<Common.CommonPersonSerchResult> list)
        {
            SerchResultList.Items.Clear();   
            foreach (Common.CommonPersonSerchResult c in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = c.ID.ToString();
                item.SubItems.Add(c.FirstName);
                item.SubItems.Add(c.LastName);
                item.SubItems.Add(c.FatherName);
                item.SubItems.Add(c.NationalCode.ToString());
                item.SubItems.Add(c.ShenasnameCode.ToString());
                item.SubItems.Add(c.BirthDate);
                item.SubItems.Add(c.State);
                item.SubItems.Add(c.City);
                item.SubItems.Add(c.PostalCode.ToString());
                item.SubItems.Add(c.SportType);
                item.SubItems.Add(c.SportStyle);
                item.SubItems.Add(c.RegisterType);
                item.SubItems.Add(c.Ghahremani);
                item.Tag = c;
                SerchResultList.Items.Add(item);
            }
        }
