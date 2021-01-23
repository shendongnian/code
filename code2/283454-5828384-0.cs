        protected void Page_Load(object sender, EventArgs e) {
            Context.Response.Buffer = false;
            FileStream inStr = null;
            byte[] buffer = new byte[1024];
            long byteCount; inStr = File.OpenRead(@"C:\Users\Downloads\sample.pdf");
            while ((byteCount = inStr.Read(buffer, 0, buffer.Length)) > 0) {
                if (Context.Response.IsClientConnected) {
                    Context.Response.ContentType = "application/pdf";
                    Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    Context.Response.Flush();
                }
            }
        }
