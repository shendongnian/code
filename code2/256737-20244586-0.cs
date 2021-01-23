    protected void uxManageSponsoredContentsDisplayer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                // A) - Some code here
                if (e.Row.RowState ==(DataControlRowState.Alternate|DataControlRowState.AlternateEdit) || e.Row.RowState == DataControlRowState.Edit )
                {
                // Here some logic to apply only to ONE ROW!
                }
                break;
             }         
        }
