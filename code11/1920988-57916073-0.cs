    Parallel.ForEach(dev, device=>  {  
        config.EnableDevice(dev[i].Info[CameraInfo.SerialNumber]);
        config.EnableAllStreams();
        Pipeline p = new Pipeline(ctx);
        p.Start(config);
        pipelines[i] = p;
        i++;;  
    }); 
