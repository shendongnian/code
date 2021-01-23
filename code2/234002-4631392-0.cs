    class Program
	{
		static void Main(string[] args)
		{
			//Load your data
			Dictionary<int, Data> data = new Dictionary<int, Data>(10);
			data.Add(10, new Data(10, Data.ViewType.A, "English1", Data.Selected.No));
			data.Add(12, new Data(12, Data.ViewType.B, "English1", Data.Selected.Yes));
			data.Add(14, new Data(14, Data.ViewType.C, "English1", Data.Selected.No));
			data.Add(16, new Data(16, Data.ViewType.C, "English1", Data.Selected.No));
			data.Add(20, new Data(20, Data.ViewType.B, "English1", Data.Selected.No));
			data.Add(22, new Data(22, Data.ViewType.C, "English1", Data.Selected.No));
			data.Add(24, new Data(24, Data.ViewType.C, "English1", Data.Selected.No));
			data.Add(40, new Data(40, Data.ViewType.A, "English1", Data.Selected.No));
			data.Add(42, new Data(42, Data.ViewType.B, "English1", Data.Selected.No));
			data.Add(45, new Data(45, Data.ViewType.C, "English1", Data.Selected.Yes));
			List<int> sortedViewOrder = data.Keys.ToList<int>();
			sortedViewOrder.Sort();
			Tree dataTree = new Tree(new TreeNode(new Data(0, Data.ViewType.A, "English1", Data.Selected.No)));
			//Assuming all your data is correctly ordered and A always has at least one B below it, B always has at least one C below it.
			for (int i = 0; i < sortedViewOrder.Count; )
			{
				TreeNode subTreeA = new TreeNode(data[sortedViewOrder[i]]);
				i++;
				while (i < data.Count && data[sortedViewOrder[i]].Type == Data.ViewType.B)
				{
					TreeNode subTreeB = new TreeNode(data[sortedViewOrder[i]]);
					i++;
					while (i < data.Count && data[sortedViewOrder[i]].Type == Data.ViewType.C)
					{
						subTreeB.AddChild(new TreeNode(data[sortedViewOrder[i]]));
						i++;
					}
					subTreeA.AddChild(subTreeB);
				}
				dataTree.Root.AddChild(subTreeA);
			}
			foreach (TreeNode childA in dataTree.Root.Children)
			{
				foreach (TreeNode childB in childA.Children)
				{
					if (childB.AllChildrenTestGUSelectedYes())
					{
						childB.Data.TestGUSelected = Data.Selected.Yes;
					}
				}
				if (childA.AllChildrenTestGUSelectedYes())
				{
					childA.Data.TestGUSelected = Data.Selected.Yes;
				}
			}
			foreach (TreeNode childA in dataTree.Root.Children)
			{
				Console.WriteLine(childA.Data.ToString());
				foreach (TreeNode childB in childA.Children)
				{
					Console.WriteLine(childB.Data.ToString());
					foreach (TreeNode childC in childB.Children)
					{
						Console.WriteLine(childC.Data.ToString());
					}
				}
			}
			Console.ReadLine();
		}
		public class Tree
		{
			public TreeNode Root { get; private set; }
			public Tree(TreeNode root)
			{
				Root = root;
			}
		}
		public class TreeNode
		{
			public Data Data { get; private set; }
			public List<TreeNode> Children { get; private set; }
			public TreeNode(Data data)
			{
				Data = data;
				Children = new List<TreeNode>();
			}
			public void AddChild(TreeNode child)
			{
				Children.Add(child);
			}
			public bool AllChildrenTestGUSelectedYes()
			{
				if (Children.Count == 0)
				{
					return Data.TestGUSelected == Data.Selected.Yes;
				}
				bool allChildrenYes = true;
				foreach (TreeNode child in Children)
				{
					if (!child.AllChildrenTestGUSelectedYes())
					{
						allChildrenYes = false;
						break;
					}
				}
				return allChildrenYes;
			}
		}
		public class Data
		{
			public int ViewOrder { get; set; }
			public ViewType Type { get; set; }
			public string TestName { get; set; }
			public Selected TestGUSelected { get; set; }
			public Data(int viewOrder, ViewType type, string testName, Selected testGUSelected)
			{
				ViewOrder = viewOrder;
				Type = type;
				TestName = testName;
				TestGUSelected = testGUSelected;
			}
			public override string ToString()
			{
				return "viewOrder:" + ViewOrder + " type:" + Type + " testName:" + TestName + " testGUSelected:" + TestGUSelected;
			}
			public enum ViewType
			{
				A, B, C
			}
			public enum Selected
			{
				Yes, No
			}
		}
	}
