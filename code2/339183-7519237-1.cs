    [ProtoContract(SkipConstructor = true)]
    public class Parent
    {
        [ProtoMember(1)]
        protected List<Child> m_Children;
        private Parent() { Initialize(); }
        [ProtoBeforeDeserialization] // could also use OnDeserializing
        private void Initialize()
        {
            m_Children = new List<Child>();
        }
        public Parent(List<Child> children)
        {
            m_Children = children;
            m_Children.ForEach(x => x.Parent = this);
        }
}
