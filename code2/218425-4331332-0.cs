    public class ControlButton : Button
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                return true;
            }
            else if (keyData == Keys.Down)
            {
                return true;
            }
            else if (keyData == Keys.Left)
            {
                return true;
            }
            else if (keyData == Keys.Right)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }
    }
