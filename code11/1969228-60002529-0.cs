    <script runat="server" language="C#">
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Request.QueryString["message"];
            
            if (String.IsNullOrEmpty(lblMessage.Text) {
                lblcard.Text = "Transaction made successfully!";
            }
        }
    </script>
