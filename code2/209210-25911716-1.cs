    private void progressBar1_Click(object sender, EventArgs e)
            {
                // Get mouse position(x) minus the width of the progressbar (so beginning of the progressbar is mousepos = 0 //
                float absoluteMouse = (PointToClient(MousePosition).X - progressBar1.Bounds.X);
                // Calculate the factor for converting the position (progbarWidth/100) //
                float calcFactor = progressBar1.Width / (float)100;
                // In the end convert the absolute mouse value to a relative mouse value by dividing the absolute mouse by the calcfactor //
                float relativeMouse = absoluteMouse / calcFactor;
                
                // Set the calculated relative value to the progressbar //
                progressBar1.Value = Convert.ToInt32(relativeMouse);
            }
