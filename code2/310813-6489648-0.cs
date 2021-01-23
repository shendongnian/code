    TableRow trow;
    TableCell tcell1, tcell2;
    for (int i = 0; i < 30; i++)
    {
       trow = new TableRow();
       tcell1 = new TableCell();
       tcell1.Controls.Add(new TextBox());
       tcell2 = new TableCell();
       tcell2.Controls.Add(new DropDownList());
       trow.Cells.Add(tcell1);
       trow.Cells.Add(tcell2);
       mytbl.Rows.Add(trow);
    }
