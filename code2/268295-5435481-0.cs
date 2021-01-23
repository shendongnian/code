        TextBox[] txtArray = new TextBox[500];
        for (int i = 0; i < txtArray.length; i++)
        {
          // instance the control
          txtArray[i] = new TextBox();
          // set some initial properties
          txtArray[i].Name = "txt" + i.ToString();
          txtArray[i].Text = "";
          // add to form
          Form1.Controls.Add(txtArray[i]);
          txtArray[i].Parent = Form1;
          // set position and size
          txtArray[i].Location = new Point(50, 50);
          txtArray[i].Size = new Size(200, 25);
        }
    .
    .
    .
    Form1.txt1.text = "Hello World!";
