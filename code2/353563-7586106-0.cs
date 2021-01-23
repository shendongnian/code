    class MyForm
    {
        TextBox new_textBox;
        void InitializeTextBox()
        {
            new_textBox = new TextBox();
            // initialization code here
            // Add it to the form
            this.Controls.Add(new_textBox);
        }
        void Button1_Click(...)
        {
            new_textBox.Text = "clicked";
        }
