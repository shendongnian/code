        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            //Prevent the user from copying text that contains non UTF-8 Characters
            if (!e.Control || e.KeyCode != Keys.V) 
                return;
            if (Clipboard.ContainsText() &&
                Clipboard.GetText().Any(c => System.Text.Encoding.UTF8.GetByteCount(new[] {c}) > 1))
            {
                char[] nonUtf8Characters = 
                    Clipboard.GetText().Where(c => System.Text.Encoding.UTF8.GetByteCount(new[] {c}) <= 1).ToArray();
                if (nonUtf8Characters.Length > 0)
                {
                    Clipboard.SetText(new String(nonUtf8Characters));
                }
                else
                {
                    Clipboard.Clear();
                }
                e.Handled = true;
            }
        }
