         private void BtnSaveStat_Click(object sender, RoutedEventArgs e)
            {
            if(STable.SelectedItem==null)
             return;
             var itemSelected= STable.SelectedItem
            
              if (!Directory.Exists(@"D:/ReportStatistics"))
              {
                Directory.CreateDirectory(@"D:/ReportStatistics");
              }
