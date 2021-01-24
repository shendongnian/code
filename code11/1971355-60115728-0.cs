public partial class main : Form
{
   // Your constructors...
   private void comboDepartures_SelectedIndexChanged(object sender, EventArgs e)
   {
      if (_arrivalsDataSource == null)
      {
          _arrivalsDataSource = new System.Data.DataTable();
          // Load _arrivalsDataSource from the database, basically how you're doing it now.
          comboArrival.DataSource = _arrivalsDataSource.DefaultView;
          comboArrival.DisplayMember = "Descriptions"
          comboArribal.ValueMember = "Descriptions"
      }
      if (comboDeparture.SelectedIndex == -1)
      {
          _arrivalsDataSource.DefaultView.RowFilter = null; // Clear the filter.
      }
      else
      {
          // Set the filter.
          _arrivalsDataSource.DefaultView.RowFilter = $"Description <> '{comboDeparture.SelectedValue}'";
      }
   }
   private System.Data.DataTable _arrivalsDataSource = null;
}
