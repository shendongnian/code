            private bool _firstTime = true;
            
            private void dataGridView1_EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
            {
                if( !_firstTime )
                {
                    return;
                }
    
                _firstTime = false;
    
                var t = e.Control as TextBox;
    
                if( t != null )
                {
                    t.KeyPress += OnKeyPress;
                }
            }
    
            private void OnKeyPress( object sender, KeyPressEventArgs e )
            {
                if( e.KeyChar != 'A' && e.KeyChar != 'B' && e.KeyChar != 'C' )
                {
                    e.Handled = true;
                }
            }
