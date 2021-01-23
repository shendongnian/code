    private void button4_Click(object sender, RoutedEventArgs e)
	{
		DllTest.Funtions Functions = new DllTest.Funtions();
		String Name = textBox1.Text;
            	String TC = textBox2.Text;
            	String path = "C:\\Users\\brandonm\\Desktop\\Backup\\XML\\test1.xml";
            	int Number = listBox2.Items.Count;
            	String[] Files = new String[Number];
            	String[] Hashes = new String[Number];
            	for (int i = 0; i < listBox2.Items.Count; i++)
            	{
			object s = listBox2.Items[i];
                	Files[i] = s.ToString();
            	}
            	for (int j = 0; j < listBox3.Items.Count; j++)
            	{
                	object s = listBox3.Items[j];
                	Hashes[j] = s.ToString();
            	}
            	Functions.XMLNew(path, Name, TC, Number, Files, Hashes);
        }
