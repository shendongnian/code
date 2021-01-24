                if (difficulty == 1)
            { 
                if (CPUPlayer == 1)
                {
                    
                    string targetString = "";
                    for (int side = 1; side <= 1; side++)
                    { 
                        for (int game = 1; game < 25; game++)
                        {
                          
                            for (int tile = 1; tile < 10; tile++)
                            {
                                targetString = SideA;
                                targetString += game.ToString();
                                targetString += tile.ToString();
                                Test.Text = targetString.ToString();
                                PictureBox target = (PictureBox)(this.Controls.Find(targetString, true))[0];
