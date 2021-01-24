    private void myPanel_MouseMove(object sender, MouseEventArgs e)
    {
            if (myPanel.BackgroundImage != null)
            {
                lblMousePos.Show();
                lblMousePos.Text = "pos (" + (e.X / 25 + 1) + ", " + ((myPanel.Size.Height - e.Y) / 25 + 1) + ")";
            }
    }
    public void myPanel_DragDrop(object sender, DragEventArgs e)
    {
        var picBlock = new PictureBox
        {
            BackColor = Color.FromArgb(255, trbRed.Value, 
            trbGreen.Value, trbBlue.Value),
    
            Image = Image.FromFile("my picture here.png"),
    
            Size = new Size(25, 24),
    
            Location = new Point((mouseX - 1) * 25, 
            this.myPanel.Height - mouseY * 24),
    
            SizeMode = PictureBoxSizeMode.Zoom,
    
            //Tag = musX.ToString() + ", " + musY.ToString()
            // You don't need the Tag property
        };
    
        picBlock.MouseMove += picBlock_mousemove;
        picBlock.MouseDown += picBlock_mousedown;
    
        this.myPanel.Controls.Add(picBlock);
    }
    public void picBlock_mousedown (object sender, MouseEventArgs e)
    {
            var picBlock = (PictureBlock)sender;
            this.panelSpel.Controls.Remove(picBlock);
            for (int i = 0; i < listX_pos.Count; i++)
            {
                if (listX_pos[i] == ((picBlock.Location.X / 25) + 1) && listY_pos[i] == (this.myPanel.Location.Y - picBlock.Location.Y / 25) - 11)
                {
                    listX_pos.RemoveAt(i);
                    listY_pos.RemoveAt(i);
                }
            }
            //pcbPicture is a picturebox with the same content of "my picture here.png"
            picBlock.DoDragDrop(pcbPicture.Image, DragDropEffects.Move);
    }
    public void picBlock_mousemove(object sender, MouseEventArgs e)
    {
            var picBlock = (PictureBlock)sender;
            if (myPanel.BackgroundImage != null)
            {
                //a label to show the position of the mouse
                lblMousePos.Show();
                Point point = myPanel.PointToClient(MousePosition);
                int mouseX = point.X / 25 + 1;
                int mouseY = (myPanel.Size.Height - point.Y) / 25 + 1;
                lblMousePos.Text = "pos (" + musX + ", " + musY + ")";
            }
    }
