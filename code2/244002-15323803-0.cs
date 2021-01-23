    int setWidth_comboBox(ComboBox cb)
    {
      int maxWidth = 0, temp = 0;
      foreach (string s in cb.Items)
      {
        temp = TextRenderer.MeasureText(s, cb.Font).Width;
        if (temp > maxWidth)
        {
          maxWidth = temp;
        }
      }
      return maxWidth + SystemInformation.VerticalScrollBarWidth;
    }
