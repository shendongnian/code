    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        var checkboxes = from c in groupBox1.Controls.OfType<CheckBox>()
                            where c.Checked
                            orderby int.Parse(c.Name.Substring(8))
                            select c;
    
        sb.Clear();
    
        foreach (var cb in  checkboxes)
        {
            // using the checkbox name here, though I expect you'll end up using the text
            sb.Append(string.Format("This is checkbox {0}", cb.Name.Substring(8)));
            sb.Append(Environment.NewLine);
        }
    
        textBox1.Text = sb.ToString();
    }
