    protected override void Render(HtmlTextWriter writer)
            {
                foreach(GridViewRow r in Gv.Rows)
                {
                    if(r.RowType==DataControlRowType.DataRow)
                    {
                        Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00");
                        Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl01");
                    }
                }
                base.Render(writer);
            }
