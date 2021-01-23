    private IEnumerable<DevExpress.XtraEditors.Controls.CheckedListBoxItem> GetCheckItems(string[] myStringArray)
    {
        foreach(string s in myStringArray)
        {
            DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
            item.Description = s;
            yield return item;
        }
    }
