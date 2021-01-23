       public class MyListBox : ListBox
        {
            public sListBox() : base()
            {
                 MouseDown += new System.Windows.Forms.MouseEventHandler( this.MouseDownFired ); 
            }
    
            private void MouseDownFired(object sender, MouseEventArgs args)
            {
              if ( args.Button == MouseButtons.Right ) 
              { 
                 SelectedItems.Clear();
              }
            }
