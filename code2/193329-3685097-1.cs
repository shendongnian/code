    public class AddTemplateToGridView : ITemplate
    {
        String columnName;
        public AddTemplateToGridView(String colname)
        {
            columnName = colname;
        }
        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {
            if (columnName == "yourField")
            {
                ComboBox cb = new ComboBox();
                cb.DataBinding += new EventHandler(cb_DataBinding);
                container.Controls.Add(cb);
            }
        }
        void cb_DataBinding(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            GridViewRow container = (GridViewRow)cb.NamingContainer; 
            Object dataValue = DataBinder.Eval(container.DataItem, columnName); 
            // Assign ComboBox vals 
        }
    }
