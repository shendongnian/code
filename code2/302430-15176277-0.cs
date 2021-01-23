            if (e.KeyData == Keys.Enter)
            {
                //do ...
                bool temp = Multiline;
                Multiline = true;
                e.Handled = true;
                Multiline = temp;
            }
        }
