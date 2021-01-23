	private static readonly DependencyProperty ColumnHeaderTextProperty = DependencyProperty.Register("ColumnHeader", typeof(string), typeof(MyDataGridColumn));
	public string ColumnHeaderText
	{
		get { return (string)(GetValue(ColumnHeaderTextProperty)); }
		set { SetValue(ColumnHeaderTextProperty, value); }
	}
	private static readonly DependencyProperty ColumnHeaderBackgroundProperty = DependencyProperty.Register("ColumnHeader", typeof(Brush), typeof(MyDataGridColumn));
	public Brush ColumnHeaderBackground
	{
		get { return (Brush)(GetValue(ColumnHeaderBackgroundProperty )); }
		set { SetValue(ColumnHeaderBackgroundProperty , value); }
	}
