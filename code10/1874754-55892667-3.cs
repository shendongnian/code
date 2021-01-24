    public void button1_Click(object sender, EventArgs e)
    {
        string url = textBox1.Text;
        string size = textBox2.Text;
        myFirstForm.listView1.Items.Add(url);
        myFirstForm.listView1.Items.Add(size);
        this.Hide();
    }
