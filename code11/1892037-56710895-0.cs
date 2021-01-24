    public class CustomDragHandler : IDragHandler
    {
        bool IDragHandler.OnDragEnter(IWebBrowser chromiumWebBrowser, IBrowser browser, IDragData dragData, DragOperationsMask mask)
        {
            dragData.Dispose();
            return true;
        }
        void IDragHandler.OnDraggableRegionsChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<DraggableRegion> regions)
        {
            throw new NotImplementedException();
        }
