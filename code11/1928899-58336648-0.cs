          //very simple method without external any DLL
          //dg is Datagrid 
          {
            string Destination = ".\.....location\_filename.xls";
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            dg.SelectAllCells();
            ApplicationCommands.Copy.Execute(null, dg);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            //dg.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(Destination);
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
           }
