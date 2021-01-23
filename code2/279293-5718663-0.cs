           switch (keyData)
            {
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                    // do something 
                default:
                char key = (char)keyData;
                if(char.IsLetterOrDigit(key)
                {
                    Console.WriteLine(key);
                }
                return base.ProcessCmdKey(ref msg, keyData);
                }
            }
