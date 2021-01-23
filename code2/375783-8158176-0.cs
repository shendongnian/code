    //Excel Application Object
	Excel.Application oExcelApp;
	this.Activate();
	//Get reference to Excel.Application from the ROT.
	oExcelApp =  (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
	//Display the name of the object.
	MessageBox.Show(oExcelApp.ActiveWorkbook.Name);
	//Release the reference.
	oExcelApp = null;
