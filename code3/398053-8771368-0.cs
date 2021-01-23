    protected void btnShowPopup_Click(object sender, EventArgs e) {
                txtPopup.Text = txtMain.Text;
                ASPxPopupControl1.ShowOnPageLoad = true;
            }
            protected void btnOK_Click(object sender, EventArgs e) {
                // TODO: your code is here to process the popup window's data at the server
                txtMain.Text = txtPopup.Text;
                ASPxPopupControl1.ShowOnPageLoad = false;
            }
