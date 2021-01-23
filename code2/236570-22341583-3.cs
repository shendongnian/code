    int count = 1;
    public System.Windows.Forms.TextBox AddNewTextBox()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            this.Controls.Add(txt);
            txt.Top = count * 25;
            txt.Left = 100;
            txt.Text = "TextBox " + this.count.ToString();
            count = count + 1;
            return txt;
        }
    private void Onbutton_Click(object sender, EventArgs e)
        {
          //Call the method AddNewTextBox that uses for Dynamically create Textbox
            AddNewTextBox();
        }
      
