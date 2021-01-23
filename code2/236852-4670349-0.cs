    bool _isInitialized = false;
    private void OnApplicationActivated(object sender, EventArgs e) {    
      if( !_isInitialized ){
        Sound.loadSounds();
        GetLocalProjects();
        GetProjects();          
        _isInitialized = true;   
      }
    }
