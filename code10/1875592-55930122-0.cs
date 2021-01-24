    public class TagsFactory : ITagsFactory
    {
        public string CreateTags(int dataType, string jsonInput)
        {
            switch(dataType)
            {
                case 1:
                    var intTagsDto = JsonConvert.DeserializeObject<TagForCreateDto1(jsonInput);
                    // your logic to create the tags below
                    ...
                    var tagsModel = GenerateTags();
                    return the JsonConvert.SerializeObject(tagsModel);
                case 5:
                    var ListTagsDto = JsonConvert.DeserializeObject<TagForCreateDto2>(jsonInput);
                    // your logic to create the tags below
                    ...
                    var tagsModel = GenerateTags();
                    return the JsonConvert.SerializeObject(tagsModel);
            }
        }
    }
