        private void Control_CustomCellAppearance(object sender, PivotCustomCellAppearanceEventArgs e)
        {
             PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
             //get value from the original source according to the row index
             String myValue = Convert.ToString(ds.GetValue(e.RowIndex, "sourceColumn"));
             
             //backgroundcolor condition
             if(myValue.Containts("something"))
             {
                e.Background = System.Windows.Media.Brushes.Green; 
             }
        }
