        private Office.IRibbonUI ribbon; //initialized via Ribbon's load event
        bool bGetVisible = false;
        //triggered by clicking a Ribbon control
        public void ShowFontGroup_Click(Office.IRibbonControl ctl)
        {
            bGetVisible = true;
            ribbon.Invalidate(); //triggers all "get" callbacks in the Ribbon
        }
        //callback triggered by invalidating the Ribbon
        public bool GroupFont_GetVisible(Office.IRibbonControl ctl)
        {
            return bGetVisible;
        }
