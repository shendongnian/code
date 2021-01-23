            _backupText = string.Empty;
            doNotPasteTextBox.TextInputStart += (sender, e) =>
                                                    {
                                                        int textParsed;
                                                        if(int.TryParse(e.Text,out textParsed))
                                                        {
                                                            _backupText = doNotPasteTextBox.Text.Insert(doNotPasteTextBox.SelectionStart, e.Text);
                                                        }else
                                                        {
                                                            e.Handled = true;
                                                        }
                                                    };
            
            doNotPasteTextBox.TextChanged += (sender, e) =>
                                                 {
                                                     int textParsed;
                                                     int selectionStart = doNotPasteTextBox.SelectionStart;
                                                     if(!int.TryParse(doNotPasteTextBox.Text, out textParsed))
                                                     {
                                                         doNotPasteTextBox.Text = _backupText;
                                                     }
                                                     doNotPasteTextBox.SelectionStart = selectionStart;
                                                 };
