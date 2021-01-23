    private void cmdfind_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(Panel))
                        //AddToList((Panel)control); //this function pass the panel object so further processing can be done 
                }                         
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
