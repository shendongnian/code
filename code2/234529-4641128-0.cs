    public class ListNode
    {
        public int Id { get; set; }
        public int? Predecessor { get; set; }
    }
    List<ListNode> myList = new List<ListNode> {
                                    new ListNode() { Id = 2, Predecessor = 1},
                                    new ListNode() { Id = 1, Predecessor = null},
                                    new ListNode() { Id = 5, Predecessor = 4},
                                    new ListNode() { Id = 3, Predecessor = 2},
                                    new ListNode() { Id = 4, Predecessor = 3}};
    var sortedbyPredecessor = myList.OrderBy(n => n.Predecessor).ToList();
