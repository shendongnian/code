    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.Adapters;
    
    namespace Sample
    {
        public class ImageButtonControlAdapter : WebControlAdapter
        {
            protected override void BeginRender(HtmlTextWriter writer)
            {
                ImageButton image = this.Control as ImageButton;
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
