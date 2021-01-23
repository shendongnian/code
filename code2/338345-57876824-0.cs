    public class Ribbon: Office.IRibbonExtensibility
    {
        private bool _buttonClicked;
        private Office.RibbonUI ribbon;
        public Ribbon()
        {
           _buttonClicked = false;
        }
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            ribbon = ribbonUI;
        }
    }
