        try 
        {
         HttpWebRequest request = (HttpWebRequest)WebRequest.Create(firstline);
         HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse
         if(HttpWResp.StatusCode ==200)
        {
        //Sucessfull code
        }
        else
        {
            //fail   code
        
         }
    
    }
    
    catch(Exception ex)
    {
    // Exception codee here
    }
