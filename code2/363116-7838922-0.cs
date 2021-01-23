    public class Item {
        public int Id { get; set;}
        public int ParentId { get; set;}
        public string Title {get; set;}
    }
    IDictionary<int, List<Item>> CreateTree(IEnumerable<Item> nodeList){
        var ret = new Dictionary<int, List<Item>>();
        foreach (var item in items) {
                if (!ret.ContainsKey(item.ParentId)) {
                    ret.Add(item.ParentId, new List<Item>());
                }
                ret[item.ParentId].Add(item);
            }
        return ret;
    }
