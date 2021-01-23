    filepath= Server.MapPath(filepath);
					FileStream strm = new FileStream(filepath, FileMode.Open, FileAccess.Read);
					byte[] fileByte = new byte[strm.Length];
					int x = strm.Read(fileByte, 0, fileByte.Length);
				
					Response.Clear();
					Response.AddHeader("Accept-Header", fileByte.Length.ToString());
					Response.AddHeader("Content-Disposition","inline; filename=" + filename);
					Response.ContentType = "application/pdf";
					Response.OutputStream.Write(fileByte, 0, fileByte.Length);
					Response.Flush();
					strm.Close();
