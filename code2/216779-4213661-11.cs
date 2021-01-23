    private int selectedIndex = -1;
    //...
    protected void myRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            selectedIndex = e.Item.ItemIndex;
            myRepeater.DataSource = MyGetDataMethod();
            myRepeater.DataBind();        
            
        }
