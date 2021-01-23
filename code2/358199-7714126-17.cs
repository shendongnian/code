    void dataGridView1_MouseHover(object sender, EventArgs e)
    {
        if (inError)
        {                
            Point pos = this.PointToClient(Cursor.Position);               
    
            if (r.Contains(pos.X - 20, pos.Y - 5))
            {                   
                t.Show("There was an error", dataGridView1.EditingControl, 3000); 
            }
        }
    }
