    List<int> NumbersList = new List<int>();
    private void button1_Click(object sender, EventArgs e)
    {
        int Input = Convert.ToInt32(textBox1.Text);
        if (!NumbersList.Exists(p => p.Equals(Input)))
        {
           NumbersList.Add(Input);
        }
        else
        {
            MessageBox.Show("The number entered is in the list","Error");
        }
    }
