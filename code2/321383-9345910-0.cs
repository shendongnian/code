        /// <summary>
        /// Reference this in HTML as <img src="/Photo/WatermarkedImage/{ID}" />
        /// Simplistic example supporting only jpeg images.
        /// </summary>
        /// <param name="ID">Photo ID</param>
        public ActionResult WatermarkedImage(Guid ID)
        {
            // Attempt to fetch the photo record from the database using Entity Framework 4.2.
            var photo = db.Photos.Find(ID);
            if (photo != null) // Found the indicated photo record.
            {
                // Create WebImage from photo data.
                // Should have 'using System.Web.Helpers' but just to make it clear...
                var wi = new System.Web.Helpers.WebImage(photo.Data); 
                
                // Apply the watermark.
                wi.AddImageWatermark(Server.MapPath("~/Content/Images/Watermark.png"), 
                                     opacity: 75, 
                                     horizontalAlign: "Center", 
                                     verticalAlign: "Bottom");
                
                // Extract byte array.
                var image = wi.GetBytes("image/jpeg");
                
                // Return byte array as jpeg.
                return File(image, "image/jpeg");
            }
            else // Did not find a record with passed ID.
            {
                return null; // 'Missing image' icon will display on browser.
            }
        }
