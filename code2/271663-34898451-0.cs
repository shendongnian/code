    private void Form1_Deactivate(object sender, EventArgs e)
    {
        if(b)
        {
             pos1 = Cursor.Position;
             b = false;
        }
        else
        { 
            pos2 = Cursor.Position
            if (pos1.x >= pos2.x){
                diffx = pos1.x - pos2.x;
            }
            else
            {
                diffx = pos2.x - pos1.x;
            }
            if (pos1.y >= pos2.y){
                diffy = pos1.y - pos2.y;
            }
            else
            {
                diffy = pos2.y - pos1.y;
            }
            area = diffx * diffy;
            //now display it in the message box by this:
            MessageBox.Show(area.ToString());
        }
    }
