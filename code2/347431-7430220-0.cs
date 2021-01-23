           public  List<string> GetNewList(List<string> list, string s)
        {
            var result = new List<string>();
            foreach (var l in list)
            {
                result.Add(l);
                result.Add(s);
            }
            result.RemoveAt(result.Count - 1);
            return result;
        }
