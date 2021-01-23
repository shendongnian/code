        public static IVsTextManager TextManager
        {
            get
            {
                if (textManager == null)
                {
                    Object obj = Package.GetGlobalService(typeof(SVsTextManager));
                    if (obj == null)
                    {
                        throw new ArgumentException("get textmanager failed in VSTextView");
                    }
                    textManager = obj as IVsTextManager;
                }
                return textManager;
            }
        }
        public static IVsTextView ActiveTextView
        {
            get
            {
                IVsTextView activeView = null;
                if (TextManager != null)
                {
                    TextManager.GetActiveView(1, activeTextBuffer, out activeView);
                }
                return activeView;
            }
        }
