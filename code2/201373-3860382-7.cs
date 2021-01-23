    public void AppendText(string text)
    {
        if (text.Length > 0)
        {
            int num;
            int num2;
            this.GetSelectionStartAndLength(out num, out num2);
            try
            {
                int endPosition = this.GetEndPosition();
                this.SelectInternal(endPosition, endPosition, endPosition);
                this.SelectedText = text;
            }
            finally
            {
                if ((base.Width == 0) || (base.Height == 0))
                {
                    this.Select(num, num2);
                }
            }
        }
    }
