    public void ProcessRequest(HttpContext context)  
    {   
       int newsId = int.Parse(context.Session["newsId"].ToString());
       int FK_UnitId = int.Parse(context.Session["UserData"].ToString());
       string dirPathForTextFiles =  ConfigurationManager.AppSettings.GetValues("ThePath").First() + "/" + "NewsTextFiles" + "/" + "UnitNum" + FK_UnitId.ToString() + "_" + "NewsNum" + newsId + "/";
       DataTable UpdatedDateTable = (DataTable)context.Session["theLastUpdatedTextFile"];
       UpdatedDateTable.AcceptChanges();
       context.Session.Add("currentTextFile", UpdatedDateTable);
       List<string> l = new List<string>(UpdatedDateTable.Rows.Count);
        
       try
       {
        
          l.Add(dirPathForTextFiles + UpdatedDateTable.Rows[0]["fileName"].ToString());
           context.Response.ContentType = getContentType(dirPathForTextFiles + UpdatedDateTable.Rows[0]["fileName"].ToString());
           using (FileStream fs = new FileStream(l[0], FileMode.Open, FileAccess.Read))
           {
              byte[] buf;
              int chunkSize = 100000;
              int bytesRead = 1;
              while(bytesRead > 0)
              {        
                  bytesRead = fs.Read(buf, 0, chunkSize);     
                  if (bytesRead > 0) context.Response.OutputStream.Write(buf, 0, buf.Length);
              }
          }
        
      }
      catch (IOException e)
      {
         string message = e.Message;
      }   
    }
