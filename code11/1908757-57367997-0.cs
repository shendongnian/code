    static async Task RunAsync()
        {
            //other logic
            List<TagDetail> tagDetail = new List<TagDetail>();
            tagDetail = await GetTagDetailAsync("api/tagdetail/?tagname=myTag&startdate=010120190000&enddate=020120190000");
            
            foreach(var item in tagDetail)
            {
                Console.WriteLine(item.value);
            }
        }
            static async Task<List<TagDetail>> GetTagDetailAsync(string path)
        {
            List<TagDetail> tagdetail = new List<TagDetail>();
            HttpResponseMessage response = await client.GetAsync(path);
            var test = response.StatusCode;
            var test2 = response.Headers;
            if (response.IsSuccessStatusCode)
            {
                tagdetail = await response.Content.ReadAsAsync<List<TagDetail>>(
            new List<MediaTypeFormatter>
            {
                new XmlMediaTypeFormatter(),
                new JsonMediaTypeFormatter()
            }); 
            }
            return tagdetail;
        }
