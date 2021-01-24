    if (RadioButton1.Checked)
        cmd.Parameters.AddWithValue("@2", RadioButton1.Text);
    if (RadioButton2.Checked)
        cmd.Parameters.AddWithValue("@2", RadioButton2.Text);
    if (RadioButton2.Checked) // <---------------------------- Should this be RadioButton3?
        cmd.Parameters.AddWithValue("@2", RadioButton3.Text);
    if (RadioButton2.Checked) // <---------------------------- Should this be RadioButton4?
        cmd.Parameters.AddWithValue("@2", RadioButton4.Text);
    if (RadioButton2.Checked) // <---------------------------- Should this be RadioButton5?
        cmd.Parameters.AddWithValue("@2", RadioButton5.Text);
    if (RadioButton2.Checked) // <---------------------------- Should this be RadioButton6?
        cmd.Parameters.AddWithValue("@2", RadioButton6.Text);
