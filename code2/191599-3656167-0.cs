        //Sends request to Google and gets the response as stream
        //imgUrl - image url for the Google static map
        public Stream getStream(string imgUrl)
        {
            Stream stream = null;
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(imgUrl);
                System.Net.WebResponse response = req.GetResponse();
                stream = response.GetResponseStream();
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        //Converts stream to image and stores the image in temp files location
        //strm - Stream containing Google map 
        //imageName - image Name to be saved in temp file
        public void SaveStreamAsImage(Stream strm,string imageName)
        {
           System.Drawing.Image img = null;
            try
            {
                img = System.Drawing.Image.FromStream(strm);
                img.Save(System.IO.Path.GetTempPath() + imageName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                strm.Dispose();
                strm.Close();
                img.Dispose();
            }            
        }
        //Deletes the temp image file after mailing to all users
        //filePath - file path of image which is to be deleted
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);                
            }
        }
        public void SendEmail()
        {
        for (iCnt = 0; iCnt < dsEmailIds.Tables[0].Rows.Count; iCnt++)
        {
         //Linked resource to embed Google map in mail LinkedResource lnkResMain; 
         if (imgPhotos.Src.Contains("maps.google.com"))
         {
             Stream strm = getStream(imgPhotos.Src);
             SaveStreamAsImage(strm, "img1");
         }
         //send mail                              
         mail.SendMail(fromAddress,dsEmailIds.Tables[0].Rows[0]["toAddress"].ToString(),lnkResMain);
         }
         delDeleteFile(System.IO.Path.GetTempPath() + "img1");
        }
