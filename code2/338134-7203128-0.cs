            //Create a new image and set it to the image that was loaded in initially.
            System.Web.UI.WebControls.Image image = loaded image;
            //Check if the image has a picture and if not put in the no_picture image.
            if (product.Image1.ToString() == "")
            {
                ((System.Web.UI.WebControls.Image)e.Item.FindControl("prodImage")).ImageUrl                = "no_picture.gif";
            }
            else
            {
                ((System.Web.UI.WebControls.Image)e.Item.FindControl("prodImage")).ImageUrl = "upload" + product.Image1.ToString();                
            }   
            //Call a function to keep the images within the borders of each repeater cell. Returns an Image object so we can access the new height/width.
            System.Web.UI.WebControls.Image dummyImg = keepAspectRatio(image, 110, 100);
            image.Width = new Unit(dummyImg.Width.Value);
            image.Height = new Unit(dummyImg.Height.Value); 
            public System.Web.UI.WebControls.Image keepAspectRatio(System.Web.UI.WebControls.Image image, double maxWidth, double maxHeight)
            {
               //Create an Image object to store width and height
               System.Web.UI.WebControls.Image dummyImage2 = new System.Web.UI.WebControls.Image();           
               //Ratio variables to calculate aspect
               double MaxRatio = maxWidth /  maxHeight;
               double ImgRatio = image.Width.Value /  image.Height.Value;
               //Compare the images width that was passed in to the max width allowed
               if (image.Width.Value > maxWidth)
               {
                  //Set the dummy images height and width
                  dummyImage2.Height = (int) Math.Round(maxWidth / ImgRatio, 0);
                  dummyImage2.Width = (int)maxWidth;            
               }
               //Compare the images height that was passed in to the max height allowed
               if (image.Height.Value > maxHeight)
               {
                  //Set the dummy images height and width
                  dummyImage2.Height = (int)Math.Round(maxWidth * ImgRatio, 0);
                  dummyImage2.Width = (int)maxHeight;            
                }
               //Returnthe dummy object so its parameters can be accessed
               return dummyImage2;
            }
                                                                                                         
