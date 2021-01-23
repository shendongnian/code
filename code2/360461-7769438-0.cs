    List<TextBox> listOfTb = MethodToFillYourList();
    var panel = new Panel { CssClass = "tbHolder" };
    foreach (var textbox in listOfTb)
    {
         panel.Controls.Add(textbox);
    }
    YourControlToAddTextBoxesTo.Controls.Add(panel);
