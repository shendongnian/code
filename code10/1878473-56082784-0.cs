	void Main()
	{
		var grandChild1 = new Node() { Name = "GrandChild1" };	
		var child1 = new Node() { Name = "Child1", Children = new List<Node> {grandChild1} };
		var child2 = new Node() { Name = "Child2" };	
		var root = new Node() { Name = "Root", Children = new List<Node> {child1, child2} };
	
		var serialized = JsonConvert.SerializeObject(root);
        Console.WriteLine(serialized);
	}
	
	public class Node
	{
		public string Name { get; set; }	
		public List<Node> Children { get; set; }
	}
