    public DataContainer Data { get; set; }
	
	private void Form2_Load(object sender, EventArgs e)
	{
		textBox1.DataBindings.Add(new Binding("Text", Data, "Text1"));
		textBox2.DataBindings.Add(new Binding("Text", Data, "Text2"));
	}
	private void button1_Click(object sender, EventArgs e)
	{
		Data.AcceptChanges();
	}
