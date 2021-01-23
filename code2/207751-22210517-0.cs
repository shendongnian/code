    public class MyDataGrid : DataGrid
    {
        protected override void OnCanExecuteDelete(CanExecuteRoutedEventArgs e)
        {
            foreach(DataRowView _row in this.SelectedItems) //assuming the grid is multiselect
            {
                //do some actions with the data that will be deleted
            }
            e.CanExecute = true; //tell the grid data can be deleted
        }
    }
