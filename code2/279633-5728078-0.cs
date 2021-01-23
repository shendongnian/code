    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using Microsoft.Office.Interop.Excel;
    using System.Windows.Forms;
    using System.Reflection;
    
    
    namespace testtesttestExcel
    {
    public partial class Form1 : Form
    {
    public Form1()
    
    {
    InitializeComponent();
    }
    
    
    //Declare these two variables globally so you can access them from both
    //Button1 and Button2.
    Microsoft.Office.Interop.Excel.Application objApp;
    Microsoft.Office.Interop.Excel._Workbook objBook;
    
    Microsoft.Office.Interop.Excel.Workbooks objBooks;
    Microsoft.Office.Interop.Excel.Sheets objSheets;
    Microsoft.Office.Interop.Excel._Worksheet objSheet;
    Microsoft.Office.Interop.Excel.Range range;
    
    
    private void button1_Click(object sender, System.EventArgs e)
    {
    
    try
    {
    // Instantiate Excel and start a new workbook.
    objApp = new Microsoft.Office.Interop.Excel.Application();
    objBooks = objApp.Workbooks;
    objBook = objBooks.Add(Missing.Value);
    objSheets = objBook.Worksheets;
    objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);
    
    //Get the range where the starting cell has the address
    //m_sStartingCell and its dimensions are m_iNumRows x m_iNumCols.
    range = objSheet.get_Range("A1", Missing.Value);
    range = range.get_Resize(5, 5);
    
    //Create an array.
    double[,] saRet = new double[5, 5];
    
    //Fill the array.
    for (long iRow = 0; iRow < 5; iRow++)
    {
    for (long iCol = 0; iCol < 5; iCol++)
    {
    //Put a counter in the cell.
    saRet[iRow, iCol] = iRow * iCol * iCol;
    }
    }
    
    //Set the range value to the array.
    range.set_Value(Missing.Value, saRet);
    objApp.Visible = true;
    objApp.UserControl = true;
    
    }
    
    catch( Exception theException )
    {
    String errorMessage;
    errorMessage = "Error: ";
    errorMessage = String.Concat( errorMessage, theException.Message );
    errorMessage = String.Concat( errorMessage, " Line: " );
    errorMessage = String.Concat( errorMessage, theException.Source );
    
    MessageBox.Show( errorMessage, "Error" );
    }
    
    
    
    Microsoft.Office.Interop.Excel.Range currentFind = null;
    Microsoft.Office.Interop.Excel.Range firstFind = null;
    
    string A = "16";
    
    // You should specify all these parameters every time you call this method,
    // since they can be overridden in the user interface.
    currentFind = objSheet.Cells.Find(A, Type.Missing,
    Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlWhole,
    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false,
    Type.Missing, Type.Missing);
    
    while (currentFind != null)
    {
    // Keep track of the first range you find.
    if (firstFind == null)
    {
    firstFind = currentFind;
    
    //textBox1.Text = currentFind.get_Address(true, true, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, false, Missing.Value);
    
    
    }
    
    // If you didn't move to a new range, you are done.
    else if (currentFind.get_Address(Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing)
    == firstFind.get_Address(Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, Type.Missing, Type.Missing))
    {
    break;
    }
    
    currentFind.Font.Color = System.Drawing.ColorTranslator.ToOl
    (System.Drawing.Color.Red);
    currentFind.Font.Bold = true;
    
    
    currentFind = objSheet.Cells.FindNext(currentFind);
    }
    
    }
    }
