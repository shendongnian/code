        protected static bool IsInDesigner
        {
            get { return (Assembly.GetEntryAssembly() == null); }
        }
         if (!MainForm.IsInDesigner)
              LoadControl();
