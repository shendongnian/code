        public MyWinForm1 WinFormReference { get; set; }
        // Sets the text of scan history in the ui
        private void SetScanHistory(string text)
        {
            if (this.WinFormReference != null)
            {
                this.WinFormReference.SetText(text);
            }
        }
