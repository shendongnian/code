private void gridViewRecords_ShowingEditor(object sender, CancelEventArgs e)
{
    //gets focused row and casts it into my object
    MyObject mo = (MyObject) gridViewRecords.GetRow(gridViewRecords.FocusedRowHandle);
    //check for my condition
    if(!(mo.Component.Inserted))
    {
          //intended cols, whose editor I want to block
          if(gridViewRecords.FocusedColumnName == "colCarrier"){
               e.Cancel = true;
          }
          else
          if(gridViewRecords.FocusedColumnName == "colInfo"){
               e.Cancel = true;
          }
    }
}
