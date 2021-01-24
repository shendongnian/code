    public static IList<string> FilterByTag(this IList<string> input, params string[] tags)
            {
                return input.Where(tmp => {     
                foreach (var tag in tags)
                {
                    if (tmp.Contains(tag))
                    {
                        result = true;
                    }
                    result = false;
                }
                return result; // Or any value that seem appropriate.
           }).ToList();
            }
