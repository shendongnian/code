    private void initialiseCustomAnimations()
	{
		compassRoseAnimation = new DoubleAnimation();
		compassRoseAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
		navigationData.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(navigationData_PropertyChanged);
	}
