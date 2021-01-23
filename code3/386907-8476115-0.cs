    public class CustomObject
    {
        public List<CustomObject> Childs = new List<CustomObject>();
        protected IEnumerable<CustomObject> GetDecendants()
        {
            foreach (var child in Childs)
            {
                yield return child;
                foreach (var grandchild in child.GetDecendants())
                {
                    yield return grandchild;
                }
            }
        }
    }
