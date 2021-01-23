    public void ProcessRequest(HttpContext context)
            {
                Byte[] yourImage = //get your image byte array
                context.Response.BinaryWrite(yourImage);
                context.Request.ContentType = "image/jpeg";
                context.Response.AddHeader("Content-Type", "image/jpeg");
                context.Response.AddHeader("Content-Length", (yourImage).LongLength.ToString());
                con.Close();
                
                context.Response.End();
                context.Response.Close();
            }
