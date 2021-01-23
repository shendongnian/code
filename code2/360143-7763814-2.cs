    <script runat="server">
      public string ServerSideFunction(string input)
      {
         Session["egSession"] = Request.QueryString["egSession"];
         public string SessionMagic(object input)
         {
             Session["egSession"] = input;
             return Session["egSession"].ToString();
         }
      }
    </script>
