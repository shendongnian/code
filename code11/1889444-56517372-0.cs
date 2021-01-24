    private void UpdateFigure(FrameworkElement figure)
    {
        figure.Width = Convert.ToDouble(objectWidthBox.Text);
        figure.Height = Convert.ToDouble(objectHeightBox.Text);
    }
    public void ChangeGraphicsValues()
    {
        // validate input values before using them
        if (objectWidthBox.Text == "")
        {
            objectWidthBox.Text = "0";
        }
        if (objectHeightBox.Text == "")
        {
            objectHeightBox.Text = "0";
        }
        if (activeTool == Tools.Rectangle)
        {
            for (int i = 0; i < rect.Count; i++)
            {
                UpdateFigure(rect[i]);
            }
        }
        else if (activeTool == Tools.Text)
        {
            for (int i = 0; i < txt.Count; i++)
            {
                UpdateFigure(txt[i]);
            }
        }
    }
