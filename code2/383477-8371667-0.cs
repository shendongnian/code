    RadioButton rb;
    for (int i = 1; i < 5; i++)
    {
        rb = new RadioButton();
        rb.AutoSize = true;
        rb.Location = new System.Drawing.Point(25, (i*25) + 25);
        rb.Name = "radioButton" + i.ToString();
        rb.Text = "radioButton" + i.ToString();
        //Add some event handler?
        this.Controls.Add(rb);
        lstRadioButton.Add(rb);
    }
