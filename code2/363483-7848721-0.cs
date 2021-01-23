        <script runat="server">
        
        protected void Page_Init(object sender, EventArgs e)
        {   
          HtmlLink csslink = new HtmlLink();
          csslink.Href = "~/red.css";
          csslink.Attributes.Add("rel", "stylesheet");
          csslink.Attributes.Add("type", "text/css");
          Page.Header.Controls.Add(csslink);    
        }
       </script>
