    private void button1_Click(object sender, System.EventArgs e)
    {
       string path;
       path = System.IO.Path.GetDirectoryName( 
          System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
       MessageBox.Show( path );
    }
