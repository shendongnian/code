    System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div.Style["float"] = "left";
                Image img = new Image();
                img.ImageUrl = "~/userdata/2/uploadedimage/batman-for-facebook.jpg";
                img.AlternateText = "Test image";
                div.Controls.Add(img);
                test1.Controls.Add(div);
    
                System.Web.UI.HtmlControls.HtmlGenericControl div1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div1.InnerText = String.Format("{0}", reader.GetString(0));
                div1.Style["float"] = "left";
                test1.Controls.Add(div1);
    
                System.Web.UI.HtmlControls.HtmlGenericControl div2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div2.Style["clear"] = "both";
                test1.Controls.Add(div2);
