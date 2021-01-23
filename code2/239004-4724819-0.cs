    for (int i = 0; i < 10; i++)
    			{
    				PictureBox pb = new PictureBox();
    				pb.Name = "pb" + i;
    				pb.Click +=new EventHandler(pb_Click);
    				this.Controls.Add(pb);
    			} 
    void pb_Click(object sender, EventArgs e)
    		{
    
    			PictureBox pb = (PictureBox) sender;
    			if (pb.Name == "pb1")
    			{
    				...
    			}
    		}
