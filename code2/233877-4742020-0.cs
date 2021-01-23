    IBaseMessage IComponent.Execute(IPipelineContext pContext, IBaseMessage pInMsg)
    {
       // assign a new CustomStream to the incoming message
        System.IO.Stream stream = pInMsg.BodyPart.GetOriginalDataStream();
        System.IO.Stream customStream = new CustomStream(stream);
        // return the message for downstream pipeline components (further down in the pipeline)
        pInMsg.BodyPart.Data = customStream;
        pContext.ResourceTracker.AddResource(customStream);
        return pInMsg;
    }
