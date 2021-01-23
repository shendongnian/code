        public void SaveIntercept(IRibbonControl control, ref bool CancelDefault)
        {
            logger.Info("Intercepted Manual Save");
            ManualSave = true;
            CancelDefault = false;
        }
