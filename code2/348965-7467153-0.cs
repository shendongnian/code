    protected void Page_Load(object sender, EventArgs e)
    {
      if(ViewState["isButtonClicked"]!=null) 
       {
            AddDropDown();
       }
    }
    
    protected void addElement(object sender, EventArgs e)
    {
        ViewState["isButtonClicked"]="yes";
        AddDropDown();
    }
    
    void AddDropDown()
    {
        HtmlTableRow tr=new HtmlTableRow();
        HtmlTableCell tc = new HtmlTableCell();
        DropDownList mylist = new DropDownList();
        ListItem myitem = new ListItem("Item1");
        mylist.Items.Add(myitem);
        myitem = new ListItem("Item2");
        mylist.Items.Add(myitem);
        myitem = new ListItem("Item3");
        mylist.Items.Add(myitem);
        tc.Controls.Add(mylist);
        tr.Cells.Add(tc);
        itempanel.Rows.Add(tr);
    }
