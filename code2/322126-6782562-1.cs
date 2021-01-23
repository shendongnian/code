      private class TagNameResolver : ValueResolver<IList<Tag>, IList<string>>
            {
                protected override IList<string> ResolveCore(IList<Tag> source)
                {
                    var tags = new List<string>();
                    foreach (var tag in source)
                    {
                        tags.Add(tag.Name);
                    }
                    return tags;
                } 
            }
