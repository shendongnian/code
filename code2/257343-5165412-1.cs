    string[] myPicturesString = {"pictureBox1", "pictureBox2", "pictureBox3", "pictureBox4"};
                PictureBox[] myPictures = new PictureBox[myPicturesString.Length];
    
                for (int i = 0; i < myPictures.Length; i++)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c.Name == myPicturesString[i])
                        {
                            myPictures[i] = (PictureBox) c;
                        }
                    }
                }
    
                MessageBox.Show(myPictures[1].Name);
