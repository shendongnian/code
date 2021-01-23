    abstract class Shape
    {
        static readonly Shape[] s_emptyChildren = new Shape[0];
        public Rect BoundingBox;
        public Transform Transform;
        public Shape[] Children = s_emptyChildren;
        public void RenderShape (DrawingContext context)
        {
            context.PushTransform (Transform ?? Transform.Identity);
            try
            {
                OnRenderShape (context);
                foreach (var shape in Children ?? s_emptyChildren)
                {
                    shape.RenderShape (context);
                }
            }
            finally
            {
                context.Pop ();
            }
        }
        protected abstract void OnRenderShape (DrawingContext context);
    }
