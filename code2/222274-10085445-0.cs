    public class ShowImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Int32 imgID;
            if (context.Request.QueryString["id"] != null)
                imgID = Convert.ToInt32(context.Request.QueryString["id"]);
            else
                throw new ArgumentException("No parameter specified");
    
            byte[] buffer = ShowEmpImage(imgID);
            bool temp = false;
            string extension = "";
            var enc = new ASCIIEncoding();
            var header = enc.GetString(buffer);
            dbClass db = new dbClass();
            extension = db.GetID("select fileExtension from tableName WHERE LOGuid=" + imgID, "fileExtension");
            if (extension == null || extension == "")
            {
    
                if (buffer[0] == 0x25 && buffer[1] == 0x50
                && buffer[2] == 0x44 && buffer[3] == 0x46)
                {
                    temp = header.StartsWith("%PDF-");
                    extension = "application/pdf";
                }
                else if (buffer[0] == 0xFF && buffer[1] == 0xD8
                && buffer[2] == 0xFF && buffer[3] == 0xE0)
                {
                    temp = header.StartsWith("%JPG-");
                    extension = "image/jpeg";
                    extension = "image/jpg";
                }
                else if (buffer[0] == 0x89 && buffer[1] == 0x50
                && buffer[2] == 0x4E && buffer[3] == 0x47)
                {
                    temp = header.StartsWith("%PNG-");
                    extension = "image/jpeg";
                    extension = "image/png";
                }
                else if (buffer[0] == 0x49 && buffer[1] == 0x49
                && buffer[2] == 0x2A && buffer[3] == 0x00)
                {
                    temp = header.StartsWith("%TIF-");
                    extension = "image/jpeg";
                    extension = "image/tiff";
                    extension = "image/tif";
                }
                else if (buffer[0] == 0x47 && buffer[1] == 0x49
                && buffer[2] == 0x46 && buffer[3] == 0x38)
                {
                    temp = header.StartsWith("%GIF-");
                    extension = "image/jpeg";
                    extension = "image/gif";
                }
                else if (buffer[0] == 0x42 && buffer[1] == 0x4D
                && buffer[2] == 0x46 && buffer[3] == 0x38)
                {
                    temp = header.StartsWith("%BMP-");
                    extension = "image/jpeg";
                    extension = "image/bmp";
                }
                else if (buffer[0] == 0x00 && buffer[1] == 0x00
                && buffer[2] == 0x01 && buffer[3] == 0x00)
                {
                    temp = header.StartsWith("%ICO-");
                    extension = "image/jpeg";
                    extension = "image/ico";
                }
                else
                    extension = "image/jpeg";
                //else
                //extension = "application/pdf";
            }
            context.Response.ContentType = extension;
            context.Response.AddHeader("content-length", buffer.Length.ToString());
            context.Response.BinaryWrite(buffer);
        }
    
        public byte[] ShowEmpImage(int imgID)
        {
            dbClass db = new dbClass();
            string sql = "SELECT LOGpdf FROM tableName WHERE LOGuid = @ID";
            SqlCommand cmd = new SqlCommand(sql, db.con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", imgID);
            object img = null;
            try
            {
                db.Connect();
                img = cmd.ExecuteScalar();
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Disconnect();
            }
            return (byte[])img;
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
