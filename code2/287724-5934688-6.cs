    try{
        // use using block around connection, calls dispose automatically when
        // block ends...
        using(var connectionWrapper = new Connexion_D()) {
            var connectedConnection = connectionWrapper.GetConnected();        
            // do CRUD
        }
    }
    catch{
        // catching Error, avoid yellow page aspx
        // Really you should probably be doing something with the exception (logging?)
        // particularly since you go to the effort of throwing it from your Connection_D
        // class.
    }
