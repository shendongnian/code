    // a simple Plain Old C Object that describes business methods.
    public class BusinessMethod
    {
        // user-friendly name
        public string Name { get; set; }
        // type that actually implements
        public Type ImplementationType { get; set; }
    }
    // ... meanwhile, back on the ranch ...
    public void OnBusinessMethodSelection ()
    {
        // 1. if selected 
        if (BusinessMethodList.SelectedItem != null)
        {
            // 2. retrieve selected item
            BusinessMethod selected = 
                (BusinessMethod)(BusinessMethodList.SelectedItem);
            // 3. request implementation of selected item from
            // IoC container
            object implementation = 
                _container.Resolve (selected.ImplementationType);
        }
    }
