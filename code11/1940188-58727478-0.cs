    public async Task<GetMediaTypesReponse> GetMediaTypes()
        {
            GetMediaTypesReponse response = new GetMediaTypesReponse();
            response.Mediatypes = new List<Dictionary<string, string>>();
            IList<Media> medias = await mediaRepository.GetAllAsync();
            foreach (var media in medias)
            {
                var item = new Dictionary<string, string>();
                foreach (var property in media.GetType().GetProperties())
                {
                    item.Add(property.Name, property.GetValue(media).ToString());
                }
                response.Mediatypes.Add(item);
            }
            return await Task.FromResult(response);
        }
