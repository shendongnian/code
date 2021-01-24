  protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = this.Calendar1.SelectedDate.ToString();
        }
protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = true;
        }
