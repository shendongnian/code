        private void CopyControlToClipboard(Control theControl)
        {
            // Copy the whole control to a clicp board
            Bitmap bm = new Bitmap(theControl.Width, theControl.Height);
            theControl.DrawToBitmap(bm, new Rectangle(0, 0, theControl.Width, theControl.Height));
            Clipboard.SetImage((Image)bm);
        }
