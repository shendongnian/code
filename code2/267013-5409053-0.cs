    //create container
                System.Web.UI.HtmlControls.HtmlGenericControl container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
    
                //create div to hold the image
                System.Web.UI.HtmlControls.HtmlGenericControl imgDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                imgDiv.ID = "imgDiv";
                
                //build the image and set properties.
                Image img = new Image();
                img.Width = new Unit(60);//pixels
                img.Height = new Unit(60);
                img.ImageUrl = "~/userdata/2/uploadedimage/batman-for-facebook.jpg";
                img.AlternateText = "Test image";
    
                //add image to image div
                imgDiv.Controls.Add(img);
    
                //create div to hold text
                System.Web.UI.HtmlControls.HtmlGenericControl postText = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                postText.ID = "postText";
                postText.InnerHtml = String.Format("{0}", reader.GetString(0));
    
                //now add the two divs to the container
                container.Controls.Add(imgDiv);
                container.Controls.Add(postText);
    
                //add the container div to the placeholder.
                PlaceHolder1.Controls.Add(container);
