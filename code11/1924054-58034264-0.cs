lang-csharp
private void LoadDataGridView()
{
   TheDataGridView.SelectionChanged -= TheDataGridView_SelectionChanged; // Remove the handler.
   try
   {
      // Load the data grid view.
   }
   finally
   {
      TheDataGridView.SelectionChanged += TheDataGridView_SelectionChanged; // Add the handler back.
   }
}
