    public SolidColorBrush background
    {
        get
        {        
            switch (this.severity)
            {
                case Severity.Error: return new SolidColorBrush(Colors.Red);                   
                case Severity.Warning: return new SolidColorBrush(Colors.Yellow);
                default: throw new Exception("severity out of bounds");
            }
        }
    }
