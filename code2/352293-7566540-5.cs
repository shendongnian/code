           public override void DataBind()
           {
                AppProduct product = (Page.GetDataItem() as AppProduct);
                img_main.Attributes.Add("src",Build_Img_Data(product.Image1));                        
                base.DataBind();
           }
           private string Build_Img_Data(byte[] imageData)
           {
               ImageType type = (ImageType)imageData[0] ;
               byte[] new_imageData = new byte[imageData.Length - 1];
               Array.ConstrainedCopy(imageData, 1, new_imageData, 0, new_imageData.Length); 
               MemoryStream ms = new MemoryStream(new_imageData);
               string base64String = string.Format("data:image/{0};base64,{1}",type.ToString(),Convert.ToBase64String(ms.ToArray()));
               return base64String;
           }       
