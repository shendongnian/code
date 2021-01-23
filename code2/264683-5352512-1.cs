    protected void gvOutlookMeldingen_Sorting(object sender, GridViewSortEventArgs e)
            {
                switch (e.SortExpression)
                {
                    case "Melder":
                        if (e.SortDirection == SortDirection.Ascending)
                        {
                            gvOutlookMeldingen.DataSource = // Asc query for Melder field;
                            gvOutlookMeldingen.DataBind();
                        }
                        else
                        {
                            gvOutlookMeldingen.DataSource = // Desc query for Melder field ;
                            gvOutlookMeldingen.DataBind();
                        }
    
                        break;
    
                    // case statements for your other fields.
                }
            }
