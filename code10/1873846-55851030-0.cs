    public class ViewModel : INotifyPropertyChanged
    {
        private readonly AxisVM axis;
        public ViewModel()
        {
            axis = new AxisVM();
            axis.PropertyChanged += Axis_PropertyChanged;      
        }
        private void Axis_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FireOnPropertyChanged(nameof(SomeDouble));
        }
        ...
    }
