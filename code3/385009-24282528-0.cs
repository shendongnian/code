    public static List<string> Parse(string data, string delimiter)
            {
                if (data == null) return null;
                if (!delimiter.EndsWith("=")) delimiter = delimiter + "=";
                if (!data.Contains(delimiter)) return null;
                //base case
                var result = new List<string>();
                int start = data.IndexOf(delimiter) + delimiter.Length;
                int length = data.IndexOf(',', start) - start;
                if (length == 0) return null; //the group is empty
                if (length > 0)
                {
                    result.Add(data.Substring(start, length));
                    //only need to recurse when the comma was found, because there could be more groups
                    var rec = Parse(data.Substring(start + length), delimiter);
                    if (rec != null) result.AddRange(rec); //can't pass null into AddRange() :(
                }
                else //no comma found after current group so just use the whole remaining string
                {
                    result.Add(data.Substring(start));
                }
                return result;
            } 
...
    var name = Parse(_cert.Subject, "CN").FirstOrDefault();
    var email = Parse(_cert.Subject, "E").FirstOrDefault();
