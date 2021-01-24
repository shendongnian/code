    public class StackyVM : BaseViewModel
    {
        private Double left;
        public Double Left
        {
            get { return left; }
            set
            {
                left = value;
                RaisePropertyChanged();
            }
        }
        private Double top;
        public Double Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged(); }
        }
        public string ImageUrl { get; set; }
    }
