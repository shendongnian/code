            string sql = "select Attachments.FileData from Contacts where ID =" +
                         lll1.Text;
            OleDbCommand vcom = new OleDbCommand(sql, cn);
            var result = vcom.ExecuteScalar(); //contains 20 extra bytes
            if (!DBNull.Value.Equals(result))
            {
                byte[] ImageByte = result as byte[];
                MemoryStream MemStream = new
                    MemoryStream(ImageByte.Skip(20).ToArray()); //Read byte starting at position 20
                Image image = Image.FromStream(MemStream);
                pictureBox1.Image = image;
            }
            else
            {
                MessageBox.Show("no value");
            }
Looking at the rest of the code, please consider using object/control names that make sense in the context, like avoiding lll1, button5, buton6 etc.
Read about ExecuteScalar [here][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.executescalar?view=netframework-4.8
