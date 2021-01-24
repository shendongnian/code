    <Slider Grid.Column="0" Minimum="0" Maximum="{Binding CurrentTrackLenght, Mode=OneWay}" Value="{Binding CurrentTrackPosition, Mode=TwoWay}" x:Name="SeekbarControl" VerticalAlignment="Center">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="PreviewMouseDown">
                            <i:InvokeCommandAction Command="{Binding TrackControlMouseDownCommand}"></i:InvokeCommandAction>
                        </i:EventTrigger>
                        <i:EventTrigger EventName="PreviewMouseUp">
                            <i:InvokeCommandAction Command="{Binding TrackControlMouseUpCommand}"></i:InvokeCommandAction>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </Slider>
    public double CurrentTrackPosition
        {
            get { return _currentTrackPosition; }
            set
            {
                if (value.Equals(_currentTrackPosition)) return;
                _currentTrackPosition = value;
                OnPropertyChanged(nameof(CurrentTrackPosition));
            }
        }
