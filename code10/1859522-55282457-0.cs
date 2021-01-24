    private void CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var behavior = new WeekHighlightBehavior();
            behavior.CalendarControl = sender;
            Interaction.GetBehaviors(args.Item).Clear();
            Interaction.GetBehaviors(args.Item).Add(behavior);
        }
    
    private void CalendarLoaded(object sender, RoutedEventArgs args)
        {
            var calendar = sender as CalendarView;
            if (calendar.SelectedDates != null && calendar.SelectedDates.Count() > 0)
            {
                foreach (var day in calendar.SelectedDates)
                {
                    calendar.SelectedDates.Remove(day);
                }
            }
            var vm = ServiceLocator.Current.GetInstance<SampleViewModel>();
            calendar.SetDisplayDate(vm.SelectedDate);
            calendar.SelectedDates.Add(vm.SelectedDate);
        }
