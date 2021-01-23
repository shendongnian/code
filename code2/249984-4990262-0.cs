    public double TopOffset
    {
        get { return (double)GetValue(TopOffsetProperty); }
        set { SetValue(TopOffsetProperty, value);
              CallPropertyChanged("TopOffset");
            }
    }
...
    TopOffset = 2;
