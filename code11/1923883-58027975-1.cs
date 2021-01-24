    //this is my test data, you should start with foreach line
    DataTable dataTbl = new DataTable();
    dataTbl.Columns.Add("ImageColumn", typeof(string));
    dataTbl.Columns.Add("SecondColumn", typeof(string));
    
    dataTbl.Rows.Add(new string[] { @"c:\temp\img1.png", "some title" });
    dataTbl.Rows.Add(new string[] { @"c:\temp\img2.png", "some title2" });
    
    //here you need to go through every row in DataTable, create Image object from path
    foreach (DataRow row in dataTbl.Rows)
    {
    	Image img = Image.FromFile(row[0].ToString()); //be sure you're getting path from correct column (first one in my example)
    	dgvNextCycleTime.Rows.Add(new object[] { img, row[1].ToString() }); //second column, with some text
    }
