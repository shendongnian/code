    for (int i = 0; i < dtimage.Rows.Count; i++)
                {
                    var row = dtimage.Rows[i];
                    Image img = (Bitmap)row["Image"];
                    byte[] Picture;
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Jpeg);
                    Picture = ms.ToArray();
                    damaged.AddRawMaterialRecommendationImage(Convert.ToInt32(txtBon.Text), Program.UserID, DateTime.Now, Picture);//row["Image"]
                   
                }
