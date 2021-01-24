		public void Inorder(Node Root)
		{
			if (root == null)
			{
				return;
			}
			Inorder(Root.left);
			Console.WriteLine(Root.GetSetNumber + " ");
			Inorder(Root.right);
		}
