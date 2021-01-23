        <asp:Button ID="btn" runat="server" Text="print something" OnClick="btn_Click" />
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["print"] == "stuff") { Print("my test content"); }
        }
        /* or pass byte[] content*/
        private void Print(string content ){ 
            Response.ContentType = "text/plain";
            Response.AddHeader("content-disposition", "attachment;filename=myFile.txt");
            // Response.BinaryWrite(content);
            Response.Write(content);
            Response.Flush(); 
            Response.End();
        }
        protected void btn_Click(object sender, EventArgs e) {
            // postbacks give you troubles if using async.
            // Will give an error when Response.End() is called.
            Response.Redirect(Request.Url + "?print=queue");
        }
