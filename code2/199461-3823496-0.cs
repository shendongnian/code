	// Get the current text view.
	IVsTextManager txtMgr = (IVsTextManager)GetService(typeof(SVsTextManager));
	int mustHaveFocus = 1;//means true
	txtMgr.GetActiveView(mustHaveFocus, null, out currentTextView);
	userData = currentTextView as IVsUserData;
	if (userData == null)// no text view 
	{
		Console.WriteLine("No text view is currently open");
		return;
	}
	//object pathAsObject;
	//Guid monikerGuid = typeof(IVsUserData).GUID;
	//userData.GetData(ref monikerGuid, out pathAsObject);
	//string docPath = (string)pathAsObject;
	// In the next 4 statments, I am trying to get access to the editor's view 
	object holder;
	Guid guidViewHost = DefGuidList.guidIWpfTextViewHost;
	userData.GetData(ref guidViewHost, out holder);
	viewHost = (IWpfTextViewHost)holder;
	// Get a snapshot of the current editor's text.
	allText = viewHost.TextView.TextSnapshot.GetText();
	
	// Get the language for the current editor.
	string language = getLanguage(viewHost.TextView);
