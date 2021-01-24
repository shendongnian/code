    EnvDTE.DTE dte = MyVSPackage.Instance.GetService<EnvDTE.DTE>();
    
    // _visibilityEvents is a private field. 
    // There is a recommendation to store VS events objects in a field 
    // to prevent them from being GCed
    _visibilityEvents = (dte?.Events as EnvDTE80.Events2)?.WindowVisibilityEvents;
	if (_visibilityEvents != null)
	{
		_visibilityEvents.WindowShowing += VisibilityEvents_WindowShowing;
		_visibilityEvents.WindowHiding += VisibilityEvents_WindowHiding;
	}
