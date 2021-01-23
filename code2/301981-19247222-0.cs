            if (GridView.AllowSorting)
            {
                foreach (TableCell tc in GridView.HeaderRow.Cells)
                {
                    if (tc.HasControls())
                    {
                        LinkButton lb = (LinkButton)tc.Controls[0];
                        if (lb != null && lb.Text.Equals("ColumnName"))
                        {                            
                            tc.Attributes.Add("onclick", "return false;");
                        }                        
                    }
                }
            }
        }
