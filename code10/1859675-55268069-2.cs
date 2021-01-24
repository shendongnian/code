    public class Position : BindableObject
    {
        public static readonly BindableProperty LatProperty = BindableProperty.Create(nameof(Lat), typeof(double), typeof(Position), 0);
        public double Lat
        {
            get { return (double)this.GetValue(LatProperty); }
            set { this.SetValue(LatProperty, value); }
        } 
        public static readonly BindableProperty LongProperty = BindableProperty.Create(nameof(Long), typeof(double), typeof(Position), 0);
        public double Long
        {
            get { return (double)this.GetValue(LongProperty); }
            set { this.SetValue(LongProperty, value); }
        }
    
        // ...
