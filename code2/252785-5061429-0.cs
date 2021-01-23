                for (int i = 0; i < 6; i++)
                {
                    //if die is not held, then assign random number to image box
                    try
                    {
                        if (holds[i].Checked == false)
                            diceImages[i].Image = iglDice.Images[rnd.Next(6)];
                        if (holds[i].Checked == true)
                        {
                            //HERE IS WHER I NEED IT TO HOLD THE DICE IF THEY ARE CHECK AND ONLY ROLL THE REMAINING DICE. UGH I'M STILL LOST... 
                        }
                        throw new ApplicationException("No dice are held");
                    }
                    
                    catch (Exception ex)
                    {
                        MessageBox.Show("You must hold at least 1 scoring dice before rolling", "Format Error");
                    }
                }
