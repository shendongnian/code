    using System.Web.UI.WebControls;
    public static void AddColumn(ref GridView gv)
        {
            BoundField field1=new BoundField();
            field1.HeaderText="Header Text";
            field1.DataField = "DataFieldName";
            gv.Columns.Add(field1);
            BoundField  field2 = new BoundField();
            field2.HeaderText = "Header Text";
            field2.DataField = "DataFieldName";
            gv.Columns.Add(field2);
        }
