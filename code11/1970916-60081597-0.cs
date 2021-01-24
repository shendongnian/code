    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<ParentGroup> allGroupElements = new List<ParentGroup>() {
                    new ParentGroup() { Id = 1, Name = "A"},
                    new ParentGroup() { Id = 2, Name = "B"},
                    new ParentGroup() { Id = 3, Name = "C"},
                    new ParentGroup() { Id = 4, Name = "D"}
                };
                List<ChildGroup> childGroupElements = new List<ChildGroup>() {
                    new ChildGroup() {  ChildId = 1, ParentId = 3},
                    new ChildGroup() {  ChildId = 1, ParentId = 4}
                };
                var groups = (from all in allGroupElements
                              join child in childGroupElements on all.Id equals child.ParentId
                              select new { all = all, child = child })
                             .ToList();
            }
        }
        public class ParentGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ChildGroup
        {
            public int ParentId { get; set; }
            public int ChildId { get; set; }
        }
