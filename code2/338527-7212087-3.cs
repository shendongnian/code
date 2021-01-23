        protected void LettersDataList_EditCommand(object source, DataListCommandEventArgs e)
        {
            LettersDataList.EditItemIndex = e.Item.ItemIndex;
            LettersDataList.DataBind();
        }
        protected void LettersDataList_CancelCommand(object source,
            DataListCommandEventArgs e)
        {
            LettersDataList.EditItemIndex = -1;
            LettersDataList.DataBind();
        }
        protected void LettersDataList_UpdateCommand(object source,
            DataListCommandEventArgs e)
        {
            //change this to your database needs
            //String categoryID =
            //     LettersDataList.DataKeys[e.Item.ItemIndex].ToString();
            //String categoryName =
            //     ((TextBox)e.Item.FindControl("textCategoryName")).Text;
            //String description =
            //     ((TextBox)e.Item.FindControl("textDescription")).Text;
            //SqlDataSource1.UpdateParameters["original_CategoryID"].DefaultValue
            //    = categoryID;
            //SqlDataSource1.UpdateParameters["categoryName"].DefaultValue
            //    = categoryName;
            //SqlDataSource1.UpdateParameters["Description"].DefaultValue
            //    = description;
            //SqlDataSource1.Update();
            LettersDataList.EditItemIndex = -1;
            LettersDataList.DataBind();
        }
