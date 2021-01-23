    class SomeComponent : ISomeComponent
    {
        public SomeComponent(
            IEnumerable<Lazy<TaskParameters,ITaskMetadata>> parameters)
        {
            // Here the names can be examined without causing instantiation.
        }
    }
