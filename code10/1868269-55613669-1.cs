        private void arcad_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Color", typeof(string));
            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", "rouge");
            table.Rows.Add(50, "Enebrel", "Sam", "vert");
            table.Rows.Add(10, "Hydralazine", "Christoff", "rouge");
            table.Rows.Add(21, "Combivent", "Janet", "vert");
            table.Rows.Add(100, "Dilantin", "Melanie", "vert");         
            arcad_Grid.ItemsSource = table.DefaultView;
        }
		
