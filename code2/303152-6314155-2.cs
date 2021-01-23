    private void pMouseMove(object sender, MouseEventArgs e)
    {
        // Debug.WriteLine(e.OriginalSource.ToString());
        HitTestResult result = VisualTreeHelper.HitTest(rect, e.GetPosition(sender as UIElement));
        if (result != null) {
            Debug.WriteLine("Mouse inside rect")
        }
        else {
            Debug.WriteLine("Mouse outside rect");
        }
    }
