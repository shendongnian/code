    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.Adapters;
    
    namespace Sample
    {
        public class ImageControlAdapter : WebControlAdapter
        {
            protected override void BeginRender(HtmlTextWriter writer)
            {
                Image image = this.Control as Image;
                if ((image != null) && !String.IsNullOrEmpty(image.ImageUrl))
                {
                    //
                    // Decide here which objects you want to change
                    //
                    if (!image.ImageUrl.StartsWith("http") && 
                        !image.ImageUrl.StartsWith("data:"))
                    {
                        image.ImageUrl = ResourceManager.GetImageCDN(image.ImageUrl);
                    }
                }
                base.BeginRender(writer);
            }
        }
    }
