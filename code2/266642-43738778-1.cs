       public void SaveImage()
        {
            string strm = "R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"; 
           //this is a simple white background image
            var myfilename= string.Format(@"{0}", Guid.NewGuid());
            //Generate unique filename
            string filepath= "D:/UserImages/" + myfilename+ ".jpeg";
            var bytess = Convert.FromBase64String(strm);
            using (var imageFile = new FileStream(filepath, FileMode.Create))
            {
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
            }
          
           
        }
