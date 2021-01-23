    LayoutControlItem lastItem = null;
    int RowWidth = 0;
    
        public void AddMyControl()
                {
                    MyControl myControl = new MyControl("");
                    myControl.Name = Guid.NewGuid().ToString();
        
                    LayoutControlItem item = new LayoutControlItem();
                    item.Name = Guid.NewGuid().ToString();
                    item.Text = "";
               
                    MyLayoutControl.BeginUpdate();
                    //We need to determine where to insert the new item. Right or Below. If there is  
                    //space on the right we insert at Right else we just add the item.
                    if(lastItem == null || lastItem != null && (MyLayoutControl.Width - UserControlWidth) < RowWidth)
                    {
                        MyLayoutControl.AddItem(item);
                        RowWidth = item.MinSize.Width;
                    }
                    else
                    {
                        MyLayoutControl.AddItem(item, lastItem, DevExpress.XtraLayout.Utils.InsertType.Right);
                    }
                    item.Control = myControl;
                    RowWidth += item.MinSize.Width;
                    lastItem = item;
                    item.Name = " ";
                    MyLayoutControl.BestFit();
                    MyLayoutControl.EndUpdate();
                }
