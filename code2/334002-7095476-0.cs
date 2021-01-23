    // DataFilePath stores the path + file name of your data file.
    using (var p = new GenericParsing.GenericParserAdapter(DataFilePath)) {        
        // Assumes your data file is fixed width, with the column widths given in the array.
        p.ColumnWidths = new int[] { 8, 12, 9, 9, 5, 11 };
        p.FirstRowHasHeader = true;
        DataTable dt = p.GetDataTable();
    
        dataGridView1.DataSource = dt;
    }
