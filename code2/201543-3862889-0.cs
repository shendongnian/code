            HttpWebResponse objResponse = null;
            var objRequest = HttpWebRequest.Create("http://google.com"); 
            objResponse = (HttpWebResponse) objRequest.GetResponse();
            if(objResponse.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("It failed");
            }else{
                Console.WriteLine("It worked");
            }
