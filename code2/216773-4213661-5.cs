    private int selectedIndex = -1;
    //...
    protected void myRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            selectedItem = e.Item.ItemIndex;
            myRepeater.DataSource = MyGetDataMethod();
            myRepeater.DataBind();        
            
        }
