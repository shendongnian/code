    Word.Table tbl = document.Tables[1];
    Word.Cell cel = tbl.Cell(1, 1);
    Word.Range rng = cel.Range;
    cel.Split(1, 2);
    //At this point, rng is at the start of the first (left-most) cell of the two
    //using new objects for the split cells
    Word.Cell newCel1 = rng.Cells[1];
    Word.Cell newCel2 = rng.Next(wdCell, 1).Cells[1];
    newCel1.Range.Text = "1";
    newCel2.Range.Text = "2";
    //Alternative: using the original cell, plus a new object for the split cell
    //Word.Cell newCel2 = rng.Next(Word.WdUnits.wdCell, 1).Cells[1];
    //cel.Range.Text = "1";
    //newCel2.Range.Text = "2";
