        public IEnumerable<string> ShortenList(string input)
        {
           List<int> list = input.Split(" ").Select(x=>int.Parse(x)).ToList();
            if (list.Count > 19)
            {
                List<string> trimmedStringList = list.Take(18).Select(x=>x.ToString()).ToList();
                trimmedStringList.Add("...");
                trimmedStringList.Add(list[list.Count-2].ToString());
                trimmedStringList.Add(list[list.Count - 1].ToString());
                return trimmedStringList;
            }
            return list.Select(x => x.ToString());
        }
