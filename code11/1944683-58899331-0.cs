	public class GraphViewModel
	{
		public string Text { get; }
		public Graph Graph { get; }
		public GraphViewModel(string text, Graph graph) => (Text, Graph) = (text, graph);
	}
