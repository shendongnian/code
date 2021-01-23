    <style type="text/css">
            #test1 .desc
            {
                padding:27.5px; 
                float:left;
                height: 100px; 
            }
            #test1 .img
            {
                float:left;
                padding:27.5px;
            }
            #test1 > div.main
            {
            border-top: thin solid #736F6E;
            border-bottom: thin solid #736F6E;
            color:#000000;
            margin:0 auto;
            white-space: pre;
            white-space: pre-wrap;
            white-space: pre-line;
            }
        </style>
    System.Web.UI.HtmlControls.HtmlGenericControl maindiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                maindiv.Attributes["class"] = "main";
    
                System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div.Attributes["class"] = "img";
                Image img = new Image();
                img.ImageUrl = "~/userdata/2/uploadedimage/batman-for-facebook.jpg";
                img.AlternateText = "Test image";
                div.Controls.Add(img);
                maindiv.Controls.Add(div);
    
                System.Web.UI.HtmlControls.HtmlGenericControl div1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div1.InnerText = String.Format("{0}", reader.GetString(0));
                div1.Attributes["class"] = "desc";
                maindiv.Controls.Add(div1);
    
                System.Web.UI.HtmlControls.HtmlGenericControl div2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                div2.Style["clear"] = "both";
                test1.Controls.Add(div2);
                test1.Controls.Add(maindiv);
