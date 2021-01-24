    DateTime today = DateTime.Today;
    // The cells that have a date between (today - 1 day) and (today + 1 day) should be red:
    var todayMinus1Day = today.AddDays(-1);
    var todayPlus1Day = today.AddDays(+1);
    var todayMinus1Month = today.AddMonths(-1);
    var todayPlus1Month = today.AddMonths(+1)
     foreach (var cell in dateCells)
     {
         if (todayMinus1Month <= cell.Date && cell.Date <= todayPlus1Month)
         {
             // either orange or red: not default:
             cell.DataGridViewCell.Style = cell.DataGridViewCell.GetInheritedStyle();
             cell.DataGridViewCell.Style.BackColor =
                 (todayMinums1Day <= cell.Date && cell.Date <= todayPlus1Day) ?
                   Color.Red : Color.Orange;
         }
         else
         {   // use the inherited style = set the cell style to null
             cell.DataGridViewCell.Style = null;
         }
    }
