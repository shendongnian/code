private void import_begin(System.Object sender, System.ComponentModel.DoWorkEventArgs args)
{
    // unpack the arguments
    System.String filename = (System.String)arguments[0];
    // you probably should inspect the file extension in `filename` to see if it
    // is at least .xls or .xlsx prior to using Controller
    try
    {   
        Controller.Excel excel = new Controller.Excel(filename);
        ...        
    }
    catch (InvalidDataException ex)
    {
        // gracefully handle the error
        // In this example we inform the user
        MessageBox.Show ("That file does not appear to be an Excel file");
    }
}
Normally you shouldn't update the UI from a worker but `MessageBox` has it's own message pump.
