    private double oldValue;
    private void SeekToMediaPosition(object sender, RangeBaseValueChangedEventArgs e)
            {
                if (isTap==true)
                {
                    ...//tap
                }
                else
                {
    
                }
                oldValue = timelineSlider.Value;
            }
    private void Slider_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
            {
    
                Slider MySlider = sender as Slider;
                double s = MySlider.Value;
                isTap = true;
            }
    
            private void TimelineSlider_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
            {
                if (oldValue == timelineSlider.Value) {
                    //tuozhuai
                    isTap = false;
                }
                else{
                    isTap = true;
                }
            }
