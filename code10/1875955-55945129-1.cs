		public void Inorder(Node Root)
		{
			if (Root == null)
			{
				return;
			}
			Inorder(Root.left);
			Console.WriteLine(Root.GetSetNumber + " ");
			Inorder(Root.right);
		}
