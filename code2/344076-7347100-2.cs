        public event EventHandler<CustomEventArgs> Validating;
    private void OnValidating(CustomEventArgs ea)
    {
        var e = Validating;
        if (e != null)
            e(this, ea);
    }
    public class CustomEventArgs:EventArgs{
        public int MyProperty { get; set; }
    }
