     public string Post(string url, string data) {
            
    
               string vystup = null;
               try
               {
                   //Our postvars
                   byte[] buffer = Encoding.ASCII.GetBytes(data);
                   //Initialisation, we use localhost, change if appliable
                   HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                   //Our method is post, otherwise the buffer (postvars) would be useless
                   WebReq.Method = "POST";
                   //We use form contentType, for the postvars.
                   WebReq.ContentType = "application/x-www-form-urlencoded";
                   //The length of the buffer (postvars) is used as contentlength.
                   WebReq.ContentLength = buffer.Length;
                   //We open a stream for writing the postvars
                   Stream PostData = WebReq.GetRequestStream();
                   //Now we write, and afterwards, we close. Closing is always important!
                   PostData.Write(buffer, 0, buffer.Length);
                   PostData.Close();
                   //Get the response handle, we have no true response yet!
                   HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                   //Let's show some information about the response
                   Console.WriteLine(WebResp.StatusCode);
                   Console.WriteLine(WebResp.Server);
    
                   //Now, we read the response (the string), and output it.
                   Stream Answer = WebResp.GetResponseStream();
                   StreamReader _Answer = new StreamReader(Answer);
                   vystup =  _Answer.ReadToEnd();
    
                   //Congratulations, you just requested your first POST page, you
                   //can now start logging into most login forms, with your application
                   //Or other examples.
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
               return vystup.Trim()+"\n";
            
            }
