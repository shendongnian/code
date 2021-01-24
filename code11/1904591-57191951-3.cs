    public static partial class JsonExtensions
    {
        public static JToken RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                return null;
			// If the parent is a JProperty, remove that instead of the token itself.
			var contained = node.Parent is JProperty ? node.Parent : node;
            contained.Remove();
            // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
            if (contained is JProperty)
                ((JProperty)node.Parent).Value = null;
            return node;
        }
    }
