     (...)
     pictureBox2.Visible = true
     checkBox1.Checked = true; 
     //=> call SetPictureBoxVisibility(true) or SetPictureBoxVisibility(false) in your Function to update the control on your GUI.
     private void SetPictureBoxVisibility(bool IsVisible)
     {
       if(pictureBox2.InvokeRequired)
       {
          pictureBox2.Invoke(new Action<bool>(SetPictureBoxVisibility,new Object[] { IsVisible })
       }
       else
       { 
          pictureBox2.Visible = isVisible;
       }
     }
