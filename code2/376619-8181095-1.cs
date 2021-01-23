        //colum2
        string sValue2 = e.Row.Cells[4].Text;
            if (Values2.Contains(sValue2))
            {
                // This value is a duplicate - color red
                colorCells(/* Get the reference for the grid view, e.g.: gridView1*/, 4, sValue2); 
            }
            else
            {
                Values2.Add(sValue2);
            }
