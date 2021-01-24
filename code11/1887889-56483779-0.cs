    public class DocItemJoin {
        public Documents d { get; set; }
        public IEnumerable<int> ig { get; set; }
    }
    var DocItems = Document.GroupJoin(Item, d => d.ID, i => i.Document, (d, ig) => new DocItemJoin { d = d, ig = ig.Select(i => i.Attribute) });
    // (Smoker AND Region-USA) OR (Non-Smoker AND Region-Europe AND Hair-Blond)    
    var ans = DocItems.Where(dig => (dig.ig.Contains(1) && dig.ig.Contains(4)) || (dig.ig.Contains(2) && dig.ig.Contains(3) && dig.ig.Contains(6)))
                      .Select(dig => dig.d);
