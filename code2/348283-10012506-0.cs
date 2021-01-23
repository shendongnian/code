        public bool OnButtonGetEnabled(Office.IRibbonControl control)
        {
            ribbon.Invalidate();
            return HaveRichTextFieldSelected(GetContextXPath());
        }
