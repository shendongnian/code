lang-csharp
private void LoadListView()
{
   // Build up the ListViewItem that you're calling emp in your original question...
   emp.UseItemStyleForSubItems = false;
   if (emp.SubItems[2].Text == "AANWEZIG")
   {
      emp.SubItems[2].BackColor = Color.Green;
   }
}
