        static private DataGridColumn create_column(string header, string p_property_name)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = header;
            column.Binding = new Binding(p_property_name);            
            return column;
        }
