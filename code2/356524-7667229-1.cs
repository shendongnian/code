    private List<CheckBox> _checkboxes = new List<CheckBox>();
    
    public void CreateTextBox( int i, StringReader r )
    {
       // ... do your stuff here
       _cb[n].Tag = tb;
       // ... finish up
       _checkboxes.Add( _cb[n] );
    }
    
    public void DeleteTextBoxButton_Click( object sender, EventArgs e )
    {
       foreach( var cb in _checkboxes )
       {
           if( cb.Checked )
           {
               TextBox tb = cb.Tag as TextBox;
               if( tb != null )
               {
                  form2.Controls.Remove( tb );
               }
            }
       }
    }
