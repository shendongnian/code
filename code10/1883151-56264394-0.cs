calendar.MouseMove += (s, e) =>
{
	if (Mouse.DirectlyOver is FrameworkElement el && 
		el.TemplatedParent is CalendarDayButton button && 
		el.DataContext is DateTime date)
	{
		// do stuff with `date`...
	}
};
