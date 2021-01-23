        // Code presenet in button click handler og ChangeIP.aspx page
        protected void btnSaveAndRedirect_Click(object sender, EventArgs e)
        {
            this.ChangeIPAddress();
            // Pass the new IP address via Query String to the Redirector.aspx page
            Response.Redirect("Redirector.aspx?ip=" + this.txtIPAddress.Text);
        }
