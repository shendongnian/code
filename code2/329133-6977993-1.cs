    class ParentClass : IZoomFunctions
    {
        // your stuff
        public IZoomFunctions ZoomFunctions 
        { 
            get { return this as IZoomFunctions; }
        }
        private void ZoomIn()
        {
            // your real code here
        }
        public void IZoomFunctions.ZoomIn()
        {
            this.ZoomIn();
        }
    }
