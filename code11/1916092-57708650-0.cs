    private Visibility m_controlUserVisibility = Visibility.Hidden;
        public Visibility ControlUserVisibility
        {
            get { return m_controlUserVisibility; }
            set
            {
                m_controlUserVisibility = value;
                OnPropertyChanged();
            }
        }
and Binding in XAML
<UserControl Visibility="{Binding ControlUserVisibility}"></UserControl> 
When you want show UserControl - write:
ControlUserVisibility = Visibility.Visible;
