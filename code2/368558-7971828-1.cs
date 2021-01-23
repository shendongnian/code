    private void button1_Click(object sender, EventArgs e)
    {
       Form2 oFrm = new Form2(this);
       oFrm.Show();
    }
    
    public string ValuesByProperty
    {
      get { return this.textBox1.Text; }
      set { this.textBox1.Text = value; }
    }
    
    public void SetViaMethod(string newValue)
    { this.textBox1.Text = newValue; }
    
    public string GetViaMethod()
    { return this.textBox1.Text; }
