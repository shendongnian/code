    private void BtnTranspose_Click(object sender, EventArgs e)
    {
      var matrix = TransposeMatrix(decGrades);
      // Create a form
      var form = new Form();
      form.Text = "Transposed Array";
      form.Size = new Size(500, 400);
      form.StartPosition = FormStartPosition.CenterParent;
      // Create a list view
      var listview = new ListView();
      listview.Dock = DockStyle.Fill;
      listview.View = View.Details;
      listview.FullRowSelect = true;
      // Initialize columns titles with first empty
      listview.Columns.Add("");
      for ( int indexD2 = 0; indexD2 < matrix.GetLength(1); indexD2++ )
        listview.Columns.Add(strStudentNames[indexD2]);
      // Add rows with first column as title
      for ( int indexD1 = 0; indexD1 < matrix.GetLength(0); indexD1++ )
      {
        var item = new ListViewItem();
        item.Text = strAssignmentNames[indexD1];
        for ( int indexD2 = 0; indexD2 < matrix.GetLength(1); indexD2++ )
          item.SubItems.Add(matrix[indexD1, indexD2].ToString());
        listview.Items.Add(item);
      }
      // Add the list view to the form and show it
      form.Controls.Add(listview);
      form.ShowDialog();
    }
