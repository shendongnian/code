    public class DoingThingsAsync : IDoThings
    {
        private readonly Container container;
        public DoingThingsAsync(Container container)
        {
            this.container = container;
        }
        public void DoThings()
        {
            Action handler = () => DoThingsNow();
            handler.BeginInvoke(null, null);        
        }
        
        private void DoThingsNow()
        {
            // Here we run in a new thread and HERE we ask
            // the container for a new DoingThings instance.
            // This way we will be sure that all its
            // dependencies are safe to use. Never move
            // dependencies from thread to thread.
            IDoThings doer =
                this.container.GetInstance<DoingThings>();
            
            doer.DoThings();
        }
    }
