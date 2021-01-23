    //validate of the comment contains some specific words which imply the TET has not reviewed the comments!
        protected void cv1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator cv = (CustomValidator)source;
            GridViewRow gvRow = (GridViewRow)cv.NamingContainer;
            TextBox editor = (TextBox)gvRow.FindControl("txtStudentComments");
    
            if (editor.Text.ToUpper().Contains("FACILITATOR TO INSERT COMMENTS HERE PLEASE"))
                args.IsValid = false;
            else
                args.IsValid = true;
        }
