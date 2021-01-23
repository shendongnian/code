    // save value
    IsolatedStorageSettings.ApplicationSettings["MyName"] = true;
    // read value
    var val = IsolatedStorageSettings.ApplicationSettings.Contains("MyName")
		? (bool) IsolatedStorageSettings.ApplicationSettings["MyName"]
		: false; // false is default value 
