    private void Slider_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
            {​
                Slider MySlider = sender as Slider;​
                myMediaElement.Position = TimeSpan.FromSeconds(MySlider.Value);​
                LeftTimeTextBlock.Text = MusicDurationConverter.ToTime((int)e.NewValue);​
            }
