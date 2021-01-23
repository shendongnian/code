    Panel myFieldSet = new Panel();
    myFieldSet.GroupingText= “Contact Details”;
    HtmlGenericControl myOrderedList = new HtmlGenericControl("ol");
    
    HtmlGenericControl listItem1 = new HtmlGenericControl ("li");
    HtmlGenericControl listItem2 = new HtmlGenericControl ("li");
    HtmlGenericControl listItem3 = new HtmlGenericControl ("li");
    
    // code here which would add labels and textboxes to the ListItems
    
    myOrderedList.Controls.Add(listItem1);
    myOrderedList.Controls.Add(listItem2);
    myOrderedList.Controls.Add(listItem3);
    
    myFieldSet.Controls.Add(myOrderedList);
    
    Form1.Controls.Add(myFieldSet);
