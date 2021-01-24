public partial MyMessageBox : Form
{
  static public Run(decimal[,] matrix)
  {
    var form = new MyMessageBox();
    form.ListView.Columns.Add("");
    for ( int indexD2 = 0; indexD2 < matrix.GetLength(1); indexD2++ )
      form.ListView.Columns.Add(strStudentNames[indexD2]);
    for ( int indexD1 = 0; indexD1 < matrix.GetLength(0); indexD1++ )
    {
      var item = new ListViewItem();
      item.Text = strAssignmentNames[indexD1];
      for ( int indexD2 = 0; indexD2 < matrix.GetLength(1); indexD2++ )
        item.SubItems.Add(matrix[indexD1, indexD2].ToString());
      form.ListView.Items.Add(item);
    }
    form.ShowDialog();  
  }
}
So you will use it like that:
    private void BtnTranspose_Click(object sender, EventArgs e)
    {
      MyMessageBox.Run(TransposeMatrix(decGrades));
    }  
