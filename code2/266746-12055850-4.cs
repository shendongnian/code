    //Making a POST request using WebClient.
    Function()
    {    
      WebClient wc = new WebClient();
            
      var URI = new Uri("http://your_uri_goes_here");
      //If any encoding is needed.
      wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
      //Or any other encoding type.
      //If any key needed
      wc.Headers["KEY"] = "Your_Key_Goes_Here";
      wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
      wc.UploadStringAsync(URI,"POST","Data_To_Be_sent");    
    }
    void wc__UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {  
         
      try            
      {          
         MessageBox.Show(e.Result); 
         //e.result fetches you the response against your POST request.         
      }
            
      catch(Exception exc)         
      {             
         MessageBox.Show(exc.ToString());            
      }
        
    }
