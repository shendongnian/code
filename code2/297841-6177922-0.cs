        protected override bool IsInputKey(Keys keyData)
        {
            bool result = false;
            Keys key = keyData & Keys.KeyCode;
            
            switch (key)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                    result = true;
                    break;
                default:
                    result = base.IsInputKey(keyData);
                    break;
            }
            return result;
        }
