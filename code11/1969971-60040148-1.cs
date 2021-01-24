        public async Task<ActionResult<ResponseDTO>> Index()
        {
            var resp = new ResponseDTO() { statuscode = 200 };//creating response object
            try
            {
                HttpClient client = _myapi.Initial();
                HttpResponseMessage res = await client.GetAsync("generate");
                if (res.IsSuccessStatusCode)
                {
                    HttpResponseMessage response = await client.GetAsync(builder.Uri);
                    //read your image from HttpResponseMessage's content as byteArray
                    var image = response.Content.ReadAsByteArrayAsync().Result;
                    //Setting ur byte array to property of class which will convert into json later
                    resp.barCodeImage = image;
                    resp.someproperty = "some other details you want to send to UI";
                }
            }
            catch (Exception e)
            {
                //In case you got error
                resp.statuscode = 500;
                resp.errormessage = e.Message;
            }
            return resp;
        }
        
