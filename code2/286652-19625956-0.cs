        protected void MyGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception is SqlException)
            {
                int sqlErrorCode = ((SqlException)e.Exception).Number;
                if (sqlErrorCode == 547)
                {
                    // SQL Error Code 547:
                    //    "The DELETE statement conflicted with the REFERENCE 
                    //     constraint "FK_SomeTable"
                    // 
                    //  You can display a friendly error message here and tell
                    //  the system that you have handled the error
                    // 
                    myTextBox_ErrorMessage.Text = @"Data could not be deleted.
                                                  Other data in the system is 
                                                  currently referencing this data.";
                    e.ExceptionHandled = true;
                }
            }
        }
