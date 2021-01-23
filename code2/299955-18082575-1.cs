    <script runat="server">
      void Logon_Click(object sender, EventArgs e)
      {
        if ((UserEmail.Text == "jchen@contoso.com") && 
                (UserPass.Text == "37Yj*99Ps"))
          {
              FormsAuthentication.RedirectFromLoginPage 
                 (UserEmail.Text, Persist.Checked);
          }
          else
          {
              Msg.Text = "Invalid credentials. Please try again.";
          }
      }
    </script>
