     using Excel = Microsoft.Office.Interop.Excel; //Excel Reference   
   
      public virtual Object ActiveSheet { get; set; }   
   
      private void button15_Click(object sender, EventArgs e)//Generate Model and Part Numbers   
      {   
            //Gets ActiveSheet to Modify
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            //Start Excel and get Active Workbook and Sheet to modify
            oXL = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); 
            oXL.Visible = true;
            oWB = (Excel.Workbook)oXL.ActiveWorkbook; 
            oSheet = (Excel.Worksheet)oWB.ActiveSheet;   
            //Cell Input
            oSheet.Cells[6, 4] = "0"; //Change Value in Cell in Excel Cell Location [y-axis, x-axis] 
       }   
