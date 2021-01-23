    private void Form_ResizeBegin(object sender, EventArgs e)
    {
      rectangleShape.CornerRadius = 0;
    }
    
    private void Form_ResizeEnd(object sender, EventArgs e)
    {
      rectangleShape.CornerRadius = 15;
    }
