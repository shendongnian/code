                if (c is System.Web.UI.HtmlControls.HtmlTableRow)
                {
                    System.Web.UI.HtmlControls.HtmlTableRow tr;
                    tr = (System.Web.UI.HtmlControls.HtmlTableRow)c;
                    foreach (Control td in tr.Controls)
                        if (td is System.Web.UI.HtmlControls.HtmlTableCell)                        
                        {
                            System.Web.UI.HtmlControls.HtmlTableCell td1;
                            td1 = (System.Web.UI.HtmlControls.HtmlTableCell)td;
                                foreach (Control txtBox in td1.Controls)
                                    if(txtBox is TextBox)
                                    {
                                        TextBox tt = txtBox as TextBox;
                                        tt.Text = string.Empty;
                                    }
                        }
                }## Heading ##
