       using Excel = Microsoft.Office.Interop.Excel; //Excel Reference 
 
       public virtual Object ActiveSheet { get; set; } //Gets ActiveSheet from Excel (MUST HAVE!!!)
         private void button15_Click(object sender, EventArgs e)
            {
            //Allows Access to Solidworks (without SDK add-in)
            SldWorks swApp;
            swApp = null;
            swApp = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
            ModelDoc2 swDoc = null;
            bool boolstatus = false;
            swDoc = ((ModelDoc2)(swApp.ActiveDoc));
            boolstatus = swDoc.Extension.SelectByID2("Design Table", "DESIGNTABLE", 0, 0, 0, false, 0, null, 0);
            //Open Solidworks Design Table
            swDoc.InsertFamilyTableEdit();
            //Gets ActiveSheet to Modify
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            //Start Excel and get Application object.
            oXL = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); 
            oXL.Visible = true;
            oWB = (Excel.Workbook)oXL.ActiveWorkbook; 
            oSheet = (Excel.Worksheet)oWB.ActiveSheet;
            //Generate Linear Guide Support in Solidworks    
            if (comboBox1.Text == "0")//No External Rails    
            {    
             sheet.Cells[6, 4] = "0"; //Cell Location [y-axis, x-axis]    
            }    
            //Close Design Table
            swDoc.CloseFamilyTable();
            //Quit Excel
            oXL.Quit();
            }
