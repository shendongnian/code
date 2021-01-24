    //declare a class to hold your data
    public class step
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parentId { get; set; }
        public List<step> childs { get; set; }
    }
    
    public void loadSteps()
    {
        var steps = new List<step>();
    
        //instead of doing this load from your db
        steps.Add(new step { id = 1, name = "t1", parentId = null });
        steps.Add(new step { id = 2, name = "t2", parentId = 1 });
        steps.Add(new step { id = 3, name = "t3", parentId = 2 });
        steps.Add(new step { id = 4, name = "t4", parentId = 1 });
        steps.Add(new step { id = 5, name = "t5", parentId = 1 });
        steps.Add(new step { id = 6, name = "t6", parentId = null });
        steps.Add(new step { id = 7, name = "t7", parentId = 6 });
    
        //build the tree from the flat data
        var tree = BuildTree(steps);
    }
    
    //build the tree using linq (this could also be done with a queue or recursion
    static List<step> BuildTree(List<step> items)
    {
        items.ForEach(i => i.childs = items.Where(ch => ch.parentId == i.id).ToList());
        return items.Where(i => i.parentId == null).ToList();
    }
