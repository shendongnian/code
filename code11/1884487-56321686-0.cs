     switch (e.Row.RowType)
                {
                    case DataControlRowType.Header:
                        //...
                        break;
                    case DataControlRowType.DataRow:
                        if((e.Row.RowState & DataControlRowState.Edit) != DataControlRowState.Edit)
                               e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(remarksGV1, "Select$" + e.Row.RowIndex.ToString()));
                        break;
                }
