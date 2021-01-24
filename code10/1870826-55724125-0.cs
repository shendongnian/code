        private void OnHotKeyHandler(HotKey hotKey)
        {
            WinForms.SendKeys.SendWait("^c");
            System.Threading.Thread.Sleep(1000);
            if (Clipboard.ContainsText())
            {
                var selectedText = Clipboard.GetText();
                Debug.Print(selectedText);
            } else
            {
                Debug.Print("Nothing selected");
            }
        }
