    <%@ Page Language="C#" Debug="true" %>
    <script runat="server">
    
        String DB = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             String DB = "";
             DB = Session["db"].ToString();
            }
        }
    
        
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList2.SelectedItem.Text=="0")
            {
                petres d = new petres();
                String petitioner=d.getpet();
            }
        }
    
    </script>
    <html>
    <head>
        ...
    </head>
    <body>
    ...
    </body>
    </html>
