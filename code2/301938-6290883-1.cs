    private void listBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
            {
                if (this.listBox.Items.Count < 1)
                    return;
                           
                ImageItem i = (ImageItem)this.listBox.Items[e.Index];
                e.Graphics.DrawImage(i.Image, e.Bounds, 0, 0, i.Image.Width, i.Image.Width, GraphicsUnit.Pixel);
            }
    
    //So i linked up the listBox_Click
    
     private void listbox_Click(object sender, EventArgs e)
            {
                ImageItem i = (ImageItem)this.listbox.Items[listbox.SelectedIndex];
                pictureBox.Image = i.Image;
            }
