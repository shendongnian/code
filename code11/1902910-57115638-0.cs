    public async Task<List<DateTime>> GetDate()
        {
            // Original Url  http://local:8796550/serv/newobj/v678/object/35b724c5424/serv/addIDinhere/dates .    
            List<DateTime> dates = new List<DateTime>();
            var Id = "xxxxxxxxxxxxxxhola57a";
            var Date = "/dates";
            var client = new HttpClient();
            var formatedUrl = string.Format("http://local:8796550/serv/newobj/v678/object/35b724c5424/serv/?id={0}&date={1}", Id, Date);
            var ServicesDateRequest = await client.GetAsync(formatedUrl);
            string oj = await ServicesDateRequest.Content.ReadAsStringAsync();
            //here deserialized it into datetime list 
            var DatesJson = JsonConvert.DeserializeObject<DateTime>(oj);
            return DatesJson;
        }
