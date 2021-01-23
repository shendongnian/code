     LiteralControl lit = new LiteralControl("<tr><td>Date Taken:</td>");
     placeHolder1.Controls.Add(lit);
     
     [Code]
     var txt = new TextBox();
     txt.Text = [Data];
     PlaceHolder1.Controls.Add(txt);
