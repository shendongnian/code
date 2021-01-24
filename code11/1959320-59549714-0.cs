       //In Xamarin
            public void UploadImage()
            {
                //create an instance of webclient
                System.Net.WebClient Client = new System.Net.WebClient();
    
                //add the header
                Client.Headers.Add("Content-Type", "binary/octet-streOpenWriteam");
    
                //uploads the file and gets the result in a byte[]
                // change `weburl/controller/actionmethod` to our weburl 
                byte[] result = Client.UploadFile("weburl/controller/actionmethod", "POST", "pathToFile");
    
                //converts the result[] to a string
                string resultString = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
            }
