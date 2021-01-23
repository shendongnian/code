	public class Branch {
		public string Name { get; set; }
		public string Link { get; set; }
		public Branch Parent { get; set; }
		public TreeBranches Children { get; private set; }
		internal Branch(string Name, string Link) {
			this.Name = Name;
			this.Link = Link;
			this.Children = new TreeBranches(this);
		} // Branch - Constructor - Overload
		internal Branch(string Name, string Link, TreeBranches Children) {
			this.Name = Name;
			this.Link = Link;
			this.Children = Children;
			this.Children.ToList().ForEach(delegate(Branch branch) {
				branch.Parent = this;
			});
		} // Branch - Constructor - Overload
		/// <summary>
		/// Returns a boolean indicating if the given Branch has any child Branches.
		/// </summary>
		public bool HasChildren {
			get { return this.Children.Count > 0; }
		} // HasChildren - Property - ReadOnly
		/// <summary>
		/// Gets the path from the oldest ancestor to the current Branch.
		/// </summary>
		public string Path {
			get {
				string Result = "";
				Branch parent = this;
				while (parent != null) {
					Result = string.Format("{0}/{1}", parent.Name, Result);
					parent = parent.Parent;
				} // while stepping up the tree
				return string.IsNullOrWhiteSpace(Result) ? "" : Result.Substring(0, Result.Length - 1);
			} // get
		} // Path - Property - ReadOnly
	} // Branch - Class
	public class TreeBranches : IList<Branch> {
		private List<Branch> branches = new List<Branch>();
		private Branch owner;
		public TreeBranches() {
			this.owner = null;
		}
		public TreeBranches(Branch owner) {
			this.owner = owner;
		}
		public void Add(Branch branch) {
			branch.Parent = this.owner;
			this.branches.Add(branch);
		}
		#region Standard IList Method Implementation
		IEnumerator<Branch> IEnumerable<Branch>.GetEnumerator() { return this.branches.GetEnumerator(); }
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.branches.GetEnumerator(); }
		public int IndexOf(Branch item) { return this.branches.IndexOf(item); }
		public void Insert(int index, Branch item) { this.branches.Insert(index, item); }
		public void RemoveAt(int index) { this.branches.RemoveAt(index); }
		public Branch this[int index] {
			get { return this.branches[index]; }
			set { this.branches[index] = value; }
		}
		public void Clear() { this.branches.Clear(); }
		public bool Contains(Branch item) { return this.branches.Contains(item); }
		public void CopyTo(Branch[] array, int arrayIndex) { this.branches.CopyTo(array, arrayIndex); }
		public int Count { get { return this.branches.Count(); } }
		public bool IsReadOnly { get { return this.IsReadOnly; } }
		public bool Remove(Branch item) { return this.branches.Remove(item); }
		#endregion Standard IList Method Implementation
	} // TreeBranches - Class
