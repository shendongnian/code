    public sealed class HttpSessionState : ICollection, IEnumerable
    {
        ...
    
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void RemoveAll()
        {
            this.Clear();
        }
    
        ...
    }
