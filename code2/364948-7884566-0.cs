    private bool isChanged = false;
    
    void Apply_sepia() {
       isChanged = true;
       // apply sepia
    }
    void close(...) {
    	if(isChanged) {
    		if(MessageBox.Show("Are you sure?", SomethingOptions.YesNo) == MessageBoxOptions.Yes) {
    			Application.Exit();
    		}
    	} else {
    		Application.Exit();
    	}
    }
