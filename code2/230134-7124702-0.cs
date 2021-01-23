    public class FakePresentationSource : PresentationSource
    {
        protected override CompositionTarget GetCompositionTargetCore()
        {
            return null;
        }
        public override Visual RootVisual { get; set; }
        public override bool IsDisposed { get { return false; } }
    }
