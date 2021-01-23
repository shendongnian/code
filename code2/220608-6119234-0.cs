      for (int counter = 0; counter <= NumberOfControls; counter++)
      {
          TextBox tb = new TextBox();
          tb.Width = 150;
          tb.Height = 18;
          tb.TextMode = TextBoxMode.SingleLine;
          tb.ID = "TextBoxID" + (counter + 1).ToString();
          // add some dummy data to textboxes
          tb.Text = "Enter Title " + counter;
          phTextBoxes.Controls.Add(tb);
          phTextBoxes.Controls.Add(new LiteralControl("<br/>"));
      }
