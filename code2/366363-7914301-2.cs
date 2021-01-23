    public class TagService : ITagService
    {      
        public void ProcessTags<TEntity>(TEntity entity, 
            Func<IEnumerable<Tag>> featureTagsFactory, string tagString) where TEntity : ITagable
        {
            var result = new List<Tag>();
            // remove any leading/trailing spaces
			tagString = tagString.Trim();
            if (tagString.IsNotNullOrEmpty())
            {
                result.AddRange(from str in tagString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(t => t.Length > 1).Distinct()
                                join tag in featureTagsFactory() on (Slug)str equals tag.Slug into tags
                                from tag in tags.DefaultIfEmpty()
                                select tag ?? new Tag(str.Trim()));
            }
            // merge tags
            foreach (var tag in entity.Tags.Except(result)) // remove unmatched tags
            {
                entity.Untag(tag);
            }
            foreach (var tag in result) // entity should check if already added
            {
                entity.Tag(tag);
            }
        }
    }
