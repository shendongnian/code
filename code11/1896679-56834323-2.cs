    DataTable mytable = new DataTable("mytable");
    objDataAdaptermytable.Fill(mytable);
    var builder3 = new StringBuilder();
    // find the longest occurring value for each column
    int[] maxLengthPerColumn = new int[mytable.Columns.Count];
    foreach (DataRow row in mytable.Rows) {
      for (int column = 0; column < mytable.Columns.Count; column++) {
        maxLengthPerColumn[column] = Math.Max(maxLengthPerColumn[column], row.ItemArray[column].ToString().Length);
      }
    }
    string[] paddedValues = new string[mytable.Columns.Count];
    foreach (DataRow row in mytable.Rows) {
      for (int column = 0; column < mytable.Columns.Count; column++) {
        // add spaces in front of the value to make it align nicely
        paddedValues[column] = row.ItemArray[column].ToString().PadLeft(maxLengthPerColumn[column]);
      }
      builder3.AppendLine(string.Join(";", paddedValues));
    }
    File.WriteAllText(@".\test.txt", builder3.ToString());
    MessageBox.Show("Data exported");
    cnn.Close();
