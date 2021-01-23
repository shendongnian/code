    Label lblTest = new Label();
    lblTest.Text = "A Test Label";
    lblTest.Location = new Point(10, 5);  //Designed in relation to a 96 dpi screen
    lblTest.Size = new Size(30, 10);      //Size Designed in relation to 96 DPI screen
    parentControl.Controls.Add(lblTest);
    //Scale Factor is calculated as mentioned by simons19
    lblTest.Scale(scaleFactor);           //Scale the control to the screen DPI.
                                          
