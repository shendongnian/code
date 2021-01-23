      using Excel = Microsoft.Office.Interop.Excel;
  
      public virtual Object ActiveSheet { get; set; }
      private void button15_Click(object sender, EventArgs e)
        {
            //Gets ActiveSheet to Modify
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            //Start Excel and get Application object.
            oXL = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); 
            oXL.Visible = true;
            oWB = (Excel.Workbook)oXL.ActiveWorkbook; 
            oSheet = (Excel.Worksheet)oWB.ActiveSheet;
            //Generate Linear Guide Supports using Design Table in Solidworks
            if (comboBox1.Text == "0")//no external rails
            {
                oSheet.Cells[6, 4] = "0"; //Change Value in Cell in Excel Cell Location [y-axis, x-axis]
            }
            //Quit Excel
            oXL.Quit();
        }
