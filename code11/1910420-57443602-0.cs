    SolidColorBrush solidColorBrush = (SolidColorBrush)MyRectangle.Fill;
    Color color = solidColorBrush.Color;
    byte r = color.R;
    byte g = color.G;
    byte b = color.B;
    MessageBox.Show($"R{r}\nG{g}\nB{b}");
         
