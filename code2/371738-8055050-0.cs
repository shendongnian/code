	/// <summary>
	/// Finds a single, strongly-typed descendant control by its ID.
	/// </summary>
	/// <typeparam name="T">The type of the descendant control to find.</typeparam>
	/// <param name="control">The root control to start the search in.</param>
	/// <param name="id">The ID of the control to find.</param>
	/// <returns>Returns a control which matches the ID and type passed in.</returns>
	public static T FindDescendantById<T>(this Control control, string id) where T : Control
	{
		return FindDescendantByIdRecursive<T>(control, id);
	}
	/// <summary>
	/// Recursive helper method which finds a single, strongly-typed descendant control by its ID.
	/// </summary>
	/// <typeparam name="T">The type of the descendant control to find.</typeparam>
	/// <param name="root">The root control to start the search in.</param>
	/// <param name="id">The ID of the control to find.</param>
	/// <returns>Returns a control which matches the ID and type passed in.</returns>
	private static T FindDescendantByIdRecursive<T>(this Control root, string id) where T : Control
	{
		if (root is T && root.ID.ToLower() == id.ToLower())
		{
			return (T)root;
		}
		else
		{
			foreach (Control child in root.Controls)
			{
				T target = FindDescendantByIdRecursive<T>(child, id);
				if (target != null)
				{
					return target;
				}
			}
			return null;
		}
	}
