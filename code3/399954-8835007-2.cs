    public class ViewDataContainer : IViewDataContainer
    {
        public ViewDataContainer(ViewDataDictionary viewData)
        {
            ViewData = viewData;
        }
        public ViewDataDictionary ViewData { get; set; }
    }
