    private void button1_Click(object sender, EventArgs e)
    {
      System.IO.TextReader reader = null;      
      try
      {
        reader = new System.IO.StreamReader("saved.txt");
        textBox1.Text = reader.ReadLine();
        textBox2.Text = reader.ReadLine();
        textBox3.Text = reader.ReadLine();
      }
      catch (Exception x)
      {
        MessageBox.Show("Exception " + x);
      }
      finally
      {
        if (reader != null)
          reader.Close();
      }
    }
