	ControlCollection controlsCollection = (ControlCollection)Properties.GetObject(PropControlsCollection); 
	if (controlsCollection != null) { 
		// PERFNOTE: This is more efficient than using Foreach.  Foreach
		// forces the creation of an array subset enum each time we 
		// enumerate
		for(int i = 0; i < controlsCollection.Count; i++) {
			Control ctl = controlsCollection[i];
			ctl.parent = null; 
			ctl.Dispose();
		} 
		Properties.SetObject(PropControlsCollection, null); 
	}
