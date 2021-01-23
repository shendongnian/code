    class MyForm : Form
    {
        public MyForm()
        {
            picturebox1.MouseDown += picturebox1_MouseDown;       
        }
    
        private void picturebox1_MouseDown( object sender, MouseEventArgs e )
        {
            if( (e.Button & MouseButtons.Left) == MouseButtons.Left )
            {
                var imagePos = e.Location; // that's it
            }
        }
    }
