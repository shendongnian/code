    private void button1_Click(object sender, EventArgs e)
    {
        int size = -1;
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
    	   string file = openFileDialog1.FileName;
    	   try
    	   {
    	      string text = File.ReadAllText(file);
    	      size = text.Length;
    	   }
    	   catch (IOException)
    	   {
    	   }
        }
        Console.WriteLine(size); // <-- Shows file size in debugging mode.
        Console.WriteLine(result); // <-- For debugging use.
    }
