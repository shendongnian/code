<Button
    Text="{Binding Status}"
    BackgroundColor="{Binding ButtonColor}"
    Command="{Binding Selected}"
    Grid.Row="0"
    Grid.RowSpan="6"
    Grid.Column="10"
    Grid.ColumnSpan="5"/>
>in your model
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isSelected;
        public bool IsSelected {
            get { return isSelected; }
            set {                 
                    isSelected = value;
                    NotifyPropertyChanged();
                    if(value)
                    {
                        ButtonColor = Color.LightGreen;
                        Status = "Remove\nInterest";
                    }
                    else
                    {
                        ButtonColor = Color.LightGray;
                        Status = "Show\nInterest";
                    }               
            }
        }
        Color buttonColor;
        public Color ButtonColor {
            get { return buttonColor; }
            set {               
                    buttonColor = value;
                    NotifyPropertyChanged();                 
            }
        }
        string status;
        public string Status {
            get { return status; }
            set {                
                    status = value;
                    NotifyPropertyChanged();            
            }
        }
        public ICommand Selected { get; private set; }
        public Model()
        {
            Selected = new Command(() => { IsSelected = !IsSelected; });
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
