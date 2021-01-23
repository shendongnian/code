     protected void grdCategory_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            if (e.Exception.InnerException.Message == "ContainBooks") // I suppose, you will throw "ContainBooks" in exception from your BLL when your category Having books
            {
                //Display Warning Message Here, that You can Delete
            }
            else
            {
                lblException.Text = e.Exception.InnerException.Message;
            }
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows != 0)
        {
            //Display Success Message that Record Deleted Successfully
        }
    }
