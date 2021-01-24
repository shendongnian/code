    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    
    public class Rectangle : INotifyPropertyChanged
    {
        private double height;
    
        public double Width { get; set; }
        public double Height { get => height; set => SetField(ref height, value); }
        
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
    
    public class RectangleViewModel : MagicViewModel<Rectangle>
    {
        public RectangleViewModel(Rectangle model)
            : base(model)
        {
            this.model = model;
            model.PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName);
        }
    
        private Rectangle model;
    
        public Rectangle Model { get => model; set => SetField(ref model, value); }
    }
    
    public class MagicViewModel<TModel> : INotifyPropertyChanged
    {
        protected readonly TModel _model;
    
        public MagicViewModel(TModel model)
        {
            _model = model;
        }
    
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var vm = new RectangleViewModel(new Rectangle());
            var calls = 0;
            vm.PropertyChanged += (sender, propChangedArgs) => calls++;
            vm.Model.Height = 10;  // magic happened here
            Debug.Assert(calls > 0);
        }
    }
