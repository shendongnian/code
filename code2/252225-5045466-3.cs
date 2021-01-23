    private void listView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
            {
                e.UseDefaultCursors = false;
    
                if (e.Effect == DragDropEffects.Copy)
                {
                    Cursor.Current = new Cursor(@"myfile.ico");
                }
            }
    
    
    
