    public class YourControl : UserControl
    {
    
        // this method will set up the internal lists for accepting
        // objects of the specified type only
        public void SetListType(Type containedType)
        {
            var listType = typeof(List<>).MakeGenericType(new[] { containedType });
            SetCollection = (IList)Activator.CreateInstance(listType);
            SubsetCollection = (IList)Activator.CreateInstance(listType);
        }
        public IList SetCollection { get; private set; }
        public IList SubsetCollection { get; private set; }
    }
    
    // usage example:
    theControl.SetListType(typeof(string));
    theControl.SetCollection.Add("some string"); // works ok
    theControl.SetCollection.Add(42); // fails, 42 is not a string
