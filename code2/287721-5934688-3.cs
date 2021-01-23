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
    }
