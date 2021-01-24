        public static IList<string> FilterByTag(this IList<string> input, params string[] tags)
        {
            return input.Where(tmp => {  
                foreach (var tag in tags)
                {
                    if (tmp.Contains(tag))
                    {
                        return true;  // tag found.  return true.
                    }
                }
                return false;  // reviewed all tags.  tag was not found.
            });
        }
