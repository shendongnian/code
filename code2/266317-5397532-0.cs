         protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
         {
            counter++;
            heightLable.Text = "clicked";
            Image tempImage = (Image)imagearry[counter];
            ImageButton1.ImageUrl = tempImage.ImageUrl;
            //Random RandomNumber = new Random(10000);
            foreach (ImageButton iii in imgButtnsArray)
            {
               Panel1.Controls.Add((Image)imagearry[fooBarCount]);
                fooBarCount++;
            }
            fooBarCount = 0;
            counter = 0;
        }
