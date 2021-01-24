        // Using 16ms because 60Hz is already good for human eyes.
        private readonly DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(16) };
        public ScrollingTextBlock()
        {
            this.InitializeComponent();
            timer.Tick += (sender, e) =>
            {
                // Calculate the total offset to scroll. It is fixed after your text is set.
                // Since we need to "scroll to the "start" of the text,
                // the offset is equal the length of your text plus the length of the space,
                // which is the difference of the ActualWidth of the two TextBlocks.
                double offset = ScrollTextBlock.ActualWidth - NormalTextBlock.ActualWidth;
                // Scroll it horizontally.
                // Notice the Math.Min here. You cannot scroll more than offset.
                // " + 2" is just the distance it advances.
                RealScrollViewer.ChangeView(Math.Min(RealScrollViewer.HorizontalOffset + 2, offset), null, null);
                // If scroll to the offset
                if (RealScrollViewer.HorizontalOffset == offset)
                {
                    // Re-display the NormalTextBlock first so that the text won't blink because they overlap.
                    NormalTextBlock.Visibility = Visibility.Visible;
                    // Hide the ScrollTextBlock.
                    // Hiding it will also set the HorizontalOffset of RealScrollViewer to 0,
                    // so that RealScrollViewer will be scrolling from the beginning of ScrollTextBlock next time.
                    ScrollTextBlock.Visibility = Visibility.Collapsed;
                    // Stop the animation/ticking.
                    timer.Stop();
                }
            };
        }
        public void StartScrolling()
        {
            // Checking timer.IsEnabled is to avoid restarting the animation when the text is already scrolling.
            // IsEnabled is true if timer has started, false if timer is stopped.
            // Checking TextScrollViewer.ScrollableWidth is for making sure the text is scrollable.
            if (timer.IsEnabled || TextScrollViewer.ScrollableWidth == 0) return;
            // Display this first so that user won't feel NormalTextBlock will be hidden.
            ScrollTextBlock.Visibility = Visibility.Visible;
            // Hide the NormalTextBlock so that it won't overlap with ScrollTextBlock when scrolling.
            NormalTextBlock.Visibility = Visibility.Collapsed;
            // Start the animation/ticking.
            timer.Start();
        }
