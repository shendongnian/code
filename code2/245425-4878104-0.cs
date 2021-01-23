            private void StartDragCustomCursor(MouseEventArgs e)
            {
    
                GiveFeedbackEventHandler handler = new GiveFeedbackEventHandler(DragSource_GiveFeedback);
                this.DragSource.GiveFeedback += handler; 
                IsDragging = true;
                DataObject data = new DataObject(System.Windows.DataFormats.Text.ToString(), "abcd");
                DragDropEffects de = DragDrop.DoDragDrop(this.DragSource, data, DragDropEffects.Move);
                this.DragSource.GiveFeedback -= handler; 
                IsDragging = false;
            }
            void DragSource_GiveFeedback(object sender, GiveFeedbackEventArgs e)
            {
                    try
                    {
                        //This loads the cursor from a stream .. 
                        if (_allOpsCursor == null)
                        {
                            using (Stream cursorStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(
    			"SimplestDragDrop.DDIcon.cur"))
                            {
                                _allOpsCursor = new Cursor(cursorStream);
                            } 
                        }
                        Mouse.SetCursor(_allOpsCursor);
    
                        e.UseDefaultCursors = false;
                        e.Handled = true;
                    }
                    finally { }
            }
