    private int _width;
            public int Width
            {
                get { return _width; }
                set
                {
                    _width = value;
                    OnPropertyChanged("SelectedCamera");                
                }
            }
    
            private int _height;
            public int Height
            {
                get { return _height; }
                set
                {
                    _height = value;
                    OnPropertyChanged("SelectedCamera");
                }
            }
    <TextBox x:Name="txtWidth" Width="150" Height="30" Text="{Binding SelectedCamera.Width, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
    <TextBox x:Name="txtHeight" Width="150" Height="30" Text="{Binding SelectedCamera.Height, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
