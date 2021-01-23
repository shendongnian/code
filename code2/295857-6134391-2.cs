    foreach(var cell in datagridview1.SelectedCells){
       try
       {
           f2.Controls[(string)cell.Tag].Text= cell.Text;
       }
       catch
       {
            //Whatever you want
       }
    }
