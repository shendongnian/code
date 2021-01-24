 <Grid
        x:Name="GridParent">
        <ScrollViewer
            x:Name="ScrollViewerParent"
            HorizontalScrollBarVisibility="Auto"
            VerticalScrollBarVisibility="Auto"
            PanningMode="Both">
            <Image
                x:Name="MainImage"
                Source="{Binding Source={x:Static local:Constants.ImagePath}}"
                IsManipulationEnabled="True"
                TouchDown="MainImage_TouchDown"
                TouchUp="MainImage_TouchUp"
                ManipulationDelta="Image_ManipulationDelta"
                ManipulationStarting="Image_ManipulationStarting"/>
        </ScrollViewer>
    </Grid>
Here is the entire code discussed above:
    public partial class MainWindow : Window
    {
        private volatile int nrOfTouchPoints;
        private object mutex = new object();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Image_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = ScrollViewerParent;
            e.Handled = true;
        }
        private void Image_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            int nrOfPoints = 0;
            lock (mutex)
            {
                nrOfPoints = nrOfTouchPoints;
            }
            if (nrOfPoints >= 2)
            {
                DataLogger.LogActionDescription($"Executed {nameof(Image_ManipulationDelta)}");
                var matrix = MainImage.LayoutTransform.Value;
                Point? centerOfPinch = (e.ManipulationContainer as FrameworkElement)?.TranslatePoint(e.ManipulationOrigin, ScrollViewerParent);
                if (centerOfPinch == null)
                {
                    return;
                }
                var deltaManipulation = e.DeltaManipulation;
                matrix.ScaleAt(deltaManipulation.Scale.X, deltaManipulation.Scale.Y, centerOfPinch.Value.X, centerOfPinch.Value.Y);
                MainImage.LayoutTransform = new MatrixTransform(matrix);
                Point? originOfManipulation = (e.ManipulationContainer as FrameworkElement)?.TranslatePoint(e.ManipulationOrigin, MainImage);
                double scrollViewerOffsetX = ScrollViewerParent.HorizontalOffset;
                double scrollViewerOffsetY = ScrollViewerParent.VerticalOffset;
                double pointMovedOnXOffset = originOfManipulation.Value.X - originOfManipulation.Value.X * deltaManipulation.Scale.X;
                double pointMovedOnYOffset = originOfManipulation.Value.Y - originOfManipulation.Value.Y * deltaManipulation.Scale.Y;
                double multiplicatorX = ScrollViewerParent.ExtentWidth / MainImage.ActualWidth;
                double multiplicatorY = ScrollViewerParent.ExtentHeight / MainImage.ActualHeight;
                ScrollViewerParent.ScrollToHorizontalOffset(scrollViewerOffsetX - pointMovedOnXOffset * multiplicatorX);
                ScrollViewerParent.ScrollToVerticalOffset(scrollViewerOffsetY - pointMovedOnYOffset * multiplicatorY);
                e.Handled = true;
            }
            else
            {
                ScrollViewerParent.ScrollToHorizontalOffset(ScrollViewerParent.HorizontalOffset - e.DeltaManipulation.Translation.X);
                ScrollViewerParent.ScrollToVerticalOffset(ScrollViewerParent.VerticalOffset - e.DeltaManipulation.Translation.Y);
            }
        }
        private void MainImage_TouchDown(object sender, TouchEventArgs e)
        {
            lock (mutex)
            {
                nrOfTouchPoints++;
            }
        }
        private void MainImage_TouchUp(object sender, TouchEventArgs e)
        {
            lock (mutex)
            {
                nrOfTouchPoints--;
            }
        }
    }
}
