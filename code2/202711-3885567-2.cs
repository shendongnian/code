     [WebMethod]
        public void PutFile(byte[] buffer, string filename, string userName) {
            BinaryWriter binWriter = new BinaryWriter(File.Open(Server.MapPath(filename),
               FileMode.CreateNew, FileAccess.ReadWrite));
            binWriter.Write(buffer);
            binWriter.Close();
        }
