    public class NativeVideoPlayerPage : ContentPage
    {
        public NativeVideoPlayerPage()
        {
            CrossMediaManager.Current.RequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1cm46bWljcm9zb2Z0OmF6dXJlOm1lZGlhc2VydmljZXM6Y29udGVudGtleWlkZW50aWZpZXIiOiI5ZGRhMGJjYy01NmZiLTQxNDMtOWQzMi0zYWI5Y2M2ZWE4MGIiLCJpc3MiOiJodHRwOi8vdGVzdGFjcy5jb20vIiwiYXVkIjoidXJuOnRlc3QiLCJleHAiOjE3MTA4MDczODl9.lJXm5hmkp5ArRIAHqVJGefW2bcTzd91iZphoKDwa6w8");
        
            const int horizontalButtonPadding = 5;
            const int verticalButtonPadding = 10;
        
            var videoView = new VideoView
            {
                Source = @"https://amssamples.streaming.mediaservices.windows.net/830584f8-f0c8-4e41-968b-6538b9380aa5/TearsOfSteelTeaser.ism/manifest(format=m3u8-aapl)";
                AspectMode = Plugin.MediaManager.Abstractions.Enums.VideoAspectMode.AspectFit
            };
        
            var playButton = new Button { Text = "Play" };
            playButton.Clicked += HandlePlayButtonClicked;
        
            var pauseButton = new Button { Text = "Pause" };
            pauseButton.Clicked += HandlePauseButtonClicked;
        
            var stopButton = new Button { Text = "Stop" };
            stopButton.Clicked += HandleStopButtonClicked;
        
            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(videoView,
                                        Constraint.Constant(0),
                                        Constraint.Constant(0),
                                        Constraint.RelativeToParent(parent => parent.Width),
                                        Constraint.RelativeToParent(parent => parent.Height));
            relativeLayout.Children.Add(playButton,
                                        Constraint.Constant(horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPlayButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(pauseButton,
                                        Constraint.RelativeToView(playButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getPauseButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
            relativeLayout.Children.Add(stopButton,
                                        Constraint.RelativeToView(pauseButton, (parent, view) => view.X + view.Width + horizontalButtonPadding),
                                        Constraint.RelativeToParent(parent => parent.Height - verticalButtonPadding - getStopButtonHeight(parent)),
                                        Constraint.RelativeToParent(parent => (parent.Width - 4 * horizontalButtonPadding) / 3));
        
            Title = "Native Video Player";
        
            Content = relativeLayout;
        
            double getPlayButtonHeight(RelativeLayout p) => playButton.Measure(p.Width, p.Height).Request.Height;
            double getPauseButtonHeight(RelativeLayout p) => pauseButton.Measure(p.Width, p.Height).Request.Height;
            double getStopButtonHeight(RelativeLayout p) => stopButton.Measure(p.Width, p.Height).Request.Height;
        }
        
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        
            CrossMediaManager.Current.Pause();
        }
        
        void HandlePlayButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Play();
        void HandleStopButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Stop();
        void HandlePauseButtonClicked(object sender, EventArgs e) => CrossMediaManager.Current.Pause();
    }
