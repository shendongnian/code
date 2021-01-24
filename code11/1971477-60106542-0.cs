    Process process = Process.GetCurrentProcess();
    var dupl = ( Process.GetProcessesByName( process.ProcessName ) );
    if( dupl.Length <= 1 ) {
    	return true;
    }
    
    foreach( var p in dupl ) {
    	if( p.Id == process.Id ) {
    		continue;
    	}
    	p.Kill();
    }
