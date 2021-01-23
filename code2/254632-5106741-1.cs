    void OptionsItemDataBound(object sender, RepeaterItemEventArgs e)
    {
         DropDownList optionValues = e.Item.FindControl("optionValues") as DropDownList;
         if (optionValues != null)
         {
             //perform logic you need here
         }
    }
