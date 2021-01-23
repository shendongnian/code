    CheckBox cb = null;
    TextBox tb = null;
    List<string> myList = new List<string>();
    for(int row = 0; row < myDG.Items.Count; row++)
    {
      for(int col = 0; col < myDG.Columns.Count; col++)
      {
        if(col < 9){
          tb = myDG.Items[row].Cells[col].Controls[0] as TextBox;
          myList.Add(tb.Text);
        }
        else{
          cb = myDG.Items[row].Cells[col].Controls[0] as CheckBox;
          myList.Add(((cb.Checked) ? "1" : "0"));
        }
      }
    }
