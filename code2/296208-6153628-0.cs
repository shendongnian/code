    public class MyBusinessLayer : IBusinessLayer
    {
        public MyBusinessLayer(ISomeDataLayer dl, ISomeServices svc) {}
    }
    
    public class MyUI
    {
        public MyUI(IBusinessLayer bl) {}
    }
