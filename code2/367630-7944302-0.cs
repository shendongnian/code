    public class SceneNode
    {
        protected internal SceneNode prev, next;
        protected internal SceneNodeContainer parent;
    
        public SceneNode Parent { get { return parent; } }
        public SceneNode PreviousNode { get { return prev; } }
        public SceneNode NextNode { get { return next; } }
    }
