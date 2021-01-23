            //...
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    System.Windows.Forms.PictureBox picturebox = new PictureBox();
                    pictureBox.Click += new Action<object, EventArgs>(
                         (sender, e) => { doStuff(x, y); }
                    );
