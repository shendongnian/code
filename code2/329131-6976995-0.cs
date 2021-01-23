    interface IZoomFunctions
    {
        public void ZoomIn();
        ...
    }
    
    class ParentClass : IZoomFunctions
    {
        public IZoomFunctions ZoomFunctions { get; }
    }
