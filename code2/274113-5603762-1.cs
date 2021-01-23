    var initResultText =
        initResult
            .Select(ir =>
                ir ? (string)null : "Initialization failed thus connection failed.");
    		
    var connectResultText =
    	connectResult
            .Select(cr => 
                String.Format("Connection {0}.", cr ? "succeeded" : "failed"));
    
    var finalResult =
    	initResultText
            .Select(irt =>
                Observable.If(() =>
                    irt == null, connectResultText, Observable.Return(irt)))
            .Merge();
