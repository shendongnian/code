    public static string GetValues()
    {
        string value = null;
    
    	using (var form = new Form1())
        {
            DialogResult result = form.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                value = form.textBox1.Text;
            }
        }
        
        return value;
    }
