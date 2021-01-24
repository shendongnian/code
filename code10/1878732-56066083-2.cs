    private IEnumerable<NumericUpDown> GetNumericUpDowns(Control parent)
    {
        for (int i = parent.Controls.Count - 1; i <= 0; i--)
        {
            if (parent.Controls[i] is NumericUpDown)
            {
                var upDown = (NumericUpDown) parent.Controls[i];
                if ((int)upDown.Tag == 1)
                    yield return upDown;
            }
        }
    }
