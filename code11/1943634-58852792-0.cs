     public static void AddItem(ListItem listitem)
        {
            if (lvValidate.InvokeRequired)
            {
                AddItemDelegate d = new AddItemDelegate (AddItem);
                lvValidate.Invoke(d, new object[] { listitem });            
            }
            else
            {
                lvValidate.Invoke(new Action(() =>
                {
                    lvValidate.Items.Add(listitem);
                }));
            }            
        } 
    delegate void AddItemDelegate(ListItem listitem);
