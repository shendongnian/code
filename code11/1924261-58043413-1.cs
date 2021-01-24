	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		if (connectionId == 3)
		{
			treeViewBookmarks = (TreeView)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IStyleConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			((Button)target).AddHandler(ToolTipService.ToolTipClosingEvent, new ToolTipEventHandler(ButtonEx_ToolTipClosing));
			break;
		case 2:
		{
			EventSetter eventSetter = new EventSetter();
			eventSetter.Event = Control.MouseDoubleClickEvent;
			eventSetter.Handler = new MouseButtonEventHandler(TreeViewItem_MouseDoubleClick);
			((Style)target).Setters.Add(eventSetter);
			break;
		}
		}
	}
