        public class GridSquare : PictureBox
        {
           bool isFirstClick = true;
           .....
           .....
           .....
           private void gridSquare_Click(object sender, EventArgs e)
            {
                   if(isFirstClick)
                   {
                       isFirstClick = false; 
                       //Set one color
                    }
                   else
                   {
                       isFirstClick = true;
                       //Set other color
                   } 
             } 
        }
