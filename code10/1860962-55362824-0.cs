        // initialize hand once after one second of start
        if(!handInitialised){
                initialWait += Time.deltaTime;
                if(initialWait > 1f){
                    OVRInput.Controller c = OVRInput.GetConnectedControllers();
                    if(c == OVRInput.Controller.LTrackedRemote || c == OVRInput.Controller.LTouch){
                        //
                    }
                    //
                    handInitialised = true;                
                }
        }
