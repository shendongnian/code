    public static readonly DependencyProperty TimeSheetRowListProperty =
         DependencyProperty.Register(
             nameof(TimeSheetRowList),
             typeof(IList<TimeSheetRow>),
             typeof(Wrapper),
             new PropertyMetadata(null));
    public IList<TimeSheetRow> TimeSheetRowList
    {
        get { return (IList<TimeSheetRow>)GetValue(TimeSheetRowListProperty); }
        set { SetValue(TimeSheetRowListProperty, value); }
    }
