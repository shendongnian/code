    protected void LoadData()
        {
            ImageGalleryBAL objImageBAl = new ImageGalleryBAL();
            DataSet ds=objImageBAl.ImageGallery_GetALLImageForSlider();
            String s="";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string imgUrl =ConfigurationManager.AppSettings["SiteURL"]+ dr["ImageName"].ToString();
                string AltText = dr["AltText"].ToString();
                s=s+"<li><img src='"+imgUrl+"' alt='"+AltText+"' width='704' height='312' /> </li>";
            }
            ULSlider.InnerHtml = s;
            
        }
