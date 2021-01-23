    if (e.Row.RowType == DataControlRowType.DataRow)
     {
          e.Row.Cells[1].Attributes.Add("class", "text");
     }
}
