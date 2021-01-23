        public async Task<ResultDTO> GetResultAsync(PostModel model)
        {
            try
            {
                using (var client = new WebApiClient())
                {
                    var serializeModel= JsonConvert.SerializeObject(model);// using Newtonsoft.Json;
                    var response = await client.PostJsonWithModelAsync<ResultDTO>("http://www.website.com/api/create", serializeModel);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
