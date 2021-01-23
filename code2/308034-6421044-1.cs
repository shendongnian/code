        public void HideDialog()
        {
            myDialogA.SizeToContent = SizeToContent.Manual;
            myDialogA.Height = 0;
            myDialogA.Width = 0;
        }
        public void UnHideDialog()
        {
            myDialogA.SizeToContent = SizeToContent.WidthAndHeight;
        }
