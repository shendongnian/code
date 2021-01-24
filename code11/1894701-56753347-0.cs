    TemplateField customField = new TemplateField();
    customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "FirstName", ControlType.HyperLink);
    customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, "First Name", ControlType.Label);
    gv.Columns.Add(customField);
     public class GridViewTemplate : ITemplate
        {
            private DataControlRowType templateType;
            private ControlType controlType;
            private string columnName;
    
            public GridViewTemplate(DataControlRowType type, string colname, ControlType contType)
            {
                templateType = type;
                columnName = colname;
                controlType = contType;
            }
    
            public void InstantiateIn(System.Web.UI.Control container)
            {
                switch (templateType)
                {
                    case DataControlRowType.Header:
                        Literal lc = new Literal();
                        lc.Text = "<b>" + columnName + "</b>";
                        container.Controls.Add(lc);
                        break;
                    case DataControlRowType.DataRow:
                        WebControl firstName = null;
                        switch (controlType)
                        {
                            case ControlType.Label:
                                firstName = new Label();
                                break;
                            case ControlType.HyperLink:
                                firstName = new HyperLink();
                                break;
                            default:
                                break;
                        }
                        firstName.DataBinding += new EventHandler(this.FirstName_DataBinding);
                        container.Controls.Add(firstName);
                        break;
                }
            }
    
            private void FirstName_DataBinding(Object sender, EventArgs e)
            {
                GridViewRow row = null;
                switch (controlType)
                {
                    case ControlType.Label:
                        Label l = (Label)sender;
                        row = (GridViewRow)l.NamingContainer;
                        l.Text = DataBinder.Eval(row.DataItem, "FirstName").ToString();
                        break;
                    case ControlType.HyperLink:
                        HyperLink l2 = (HyperLink)sender;
                        row = (GridViewRow)l2.NamingContainer;
                        l2.Text = DataBinder.Eval(row.DataItem, "FirstName").ToString();
                        l2.NavigateUrl = "https://www.google.com";
                        break;
                }
            }
        }
        public enum ControlType
        {
            Label = 1,
            HyperLink = 2
        }
