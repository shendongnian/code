    private void BtnSaveStat_Click(object sender, RoutedEventArgs e)
    {
      if (StatTable.SelectedItem == null)
        return;
      var filename = string.Concat("Filename", DateTime.Now.ToString("ddMMyyHHmmss"), ".txt");//THIS STRING ALLOW TO BUILD FILES EVERY TIME THE USER CHANGE ITEM AND WANTO TO PRINT IT
      DataRowView var3 = (DataRowView)StatTable.SelectedItem;
      string nome = var3.Row["NItem"].ToString();
      string path = var3.Row["P"].ToString();
      string datS = var3.Row["DStart"].ToString();
      string datE = var3.Row["DEnd"].ToString();
      string ResI = var3.Row["RItem"].ToString();
      string Rep = var3.Row["Rep"].ToString();
      if (!Directory.Exists(@"D:/ReportStatistics"))
      {
        Directory.CreateDirectory(@"D:/ReportStatistics");
      }
      string file = Path.Combine(@"D:/ReportStatistics", filename);
      using (TextWriter tw1 = new StreamWriter(file, true))
      {
         
          tw1.WriteLine(nome+" "+path+" "+ datS+" "+datE+" "+ ResI+" "+ Rep);
          
      }
      MessageBox.Show("Line Saved");
    }
