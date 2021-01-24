    private void Whatever_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
    	var menu = e.Menu;
    	var hi = e.HitInfo;
    	if (!(sender is GridView view)) 
            return;
    
    	var inDetails = (hi.HitTest == GridHitTest.EmptyRow);
    	if (menu == null && inDetails)
    	{
    		menu = new DevExpress.XtraGrid.Menu.GridViewMenu(view);
    		e.Menu = menu;
    	}
    	if (menu == null) return;
    
    	//If there are any entries, show "Duplicate" button
    	var rowHandle = hi.RowHandle;
    	if (!view.IsDataRow(rowHandle)) return;
    	var mnuDuplicate = new DXMenuItem("Duplicate",
    		async delegate { await ClickDuplicate(); },
    		Properties.Resources.copy_16x16)
    	{
    		BeginGroup = true
    	};
    	menu.Items.Add(mnuDuplicate);
    }
