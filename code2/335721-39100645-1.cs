    namespace Add_in
    {
    [ComVisible(true)]
    public class MyRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        public MyRibbon()
        {
            
        }
        public Bitmap Icon1(Office.IRibbonControl control)
        {
            return (Bitmap)Properties.Resources.ResourceManager.GetObject("Icon1");
        }
   
