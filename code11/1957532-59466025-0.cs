        public List<int> GetChilds(int input) {
            var result = new List<int>();
            var res = Childs(input);
            if (res.Count == 0)
                result.Add(input);
            foreach (var item in res) {
                if (categoriesMapping.Count(x => x.CatID == item) == 0) {
                    result.Add(item);
                }
                else {
                    var childs = Childs(item);
                    foreach(var item2 in childs) {
                        GetChilds(item2);
                    }
                }
            }
            result.Sort();
            return result;
        }
        public List<int> Childs(int input)
        {
            return categoriesMapping.Where(x => x.CatID == input).Select(x => x.MapCatID).ToList() ?? new List<int>();
        } 
