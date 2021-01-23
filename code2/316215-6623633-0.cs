    public static readonly DependencyProperty SelectedDayProperty =
            DependencyProperty.Register("SelectedDay", typeof(Day), typeof(type_of_yourcontrol for instance DatePicker?));
    public Day SelectedDay
    {
         get { return (Day)GetValue(SelectedDayProperty); }
         set { SetValue(SelectedDayProperty, value); }
    }
