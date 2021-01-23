    foreach(var cell in datagridview1.SelectedCells){
       try
       {
           f2.Controls[cell.Tag].Text= cell.Text;
       }
       catch
       {
            //Whatever you want
       }
    }
