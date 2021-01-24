    private void btnZoom_Click(object sender, RoutedEventArgs e)
    {
        var st = (ScaleTransform)imgViewer.LayoutTransform;
        if ((st.ScaleX + 0.2) > 3 || (st.ScaleY + 0.2) > 3)
            return;
        st.ScaleX += 0.2;
        st.ScaleY += 0.2;
        imgViewer.LayoutTransform = st;
    }
    private void btnZoomOut_Click(object sender, RoutedEventArgs e)
    {
        var st = (ScaleTransform)imgViewer.LayoutTransform;
        if ((st.ScaleX - 0.2) < 0.8 || (st.ScaleY - 0.2) < 0.8)
            return;
        st.ScaleX += -0.2;
        st.ScaleY += -0.2;
        imgViewer.LayoutTransform = st;
    }
    public void ResetImagePosition()
            {
                var st = (ScaleTransform)imgViewer.LayoutTransform;
                st.ScaleX = 1;
                st.ScaleY = 1;
                imgViewer.LayoutTransform = st;
                svImageViewer.ScrollToHome();
            }
    public void SetControlSizes()
            {
                gridPreviewWidth = Window.ActualWidth - 30;
                svImageViewerHeight = Window.ActualHeight-200;
                svImageViewerWidth = Window.ActualWidth-100 ;
            }
