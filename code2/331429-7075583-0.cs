    private void ordresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // a flag to store if the child form is opened or not
            bool found = false;   
            // get all of the MDI children in an array
            Form[] charr = this.MdiChildren;
            if (charr.Length == 0)     // no child form is opened
            {
                Lordre myPatients = new Lordre();
                myPatients.MdiParent = this;
                // The StartPosition property is essential
                // for the location property to work
                myPatients.StartPosition = FormStartPosition.Manual;
                myPatients.Location = new Point(0,0);
                myPatients.Show();
            }
            else     // child forms are opened
            {
                foreach (Form chform in charr)
                {
                    if (chform.Tag.ToString() == "Ordre")  // one instance of the form is already opened
                    {
                        chform.Activate();
                        found = true;
                        break;   // exit loop
                    }
                    else
                        found = false;      // make sure flag is set to false if the form is not found
                }
                if (found == false)    
                {
                    Lordre myPatients = new Lordre();
                    myPatients.MdiParent = this;
                    // The StartPosition property is essential
                    // for the location property to work
                    myPatients.StartPosition = FormStartPosition.Manual;
                    myPatients.Location = new Point(0,0);
                    myPatients.Show();
                }
            }  
        }
