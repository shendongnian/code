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
                    // Don't modify external URLs or data URIs
                    //
                    if (!image.ImageUrl.StartsWith("http") && 
                        !image.ImageUrl.StartsWith("data:"))
                    {
                        image.ImageUrl = image.CanonicalUrl(image.ImageUrl);
                    }
                }
                base.BeginRender(writer);
            }
        }
    }
