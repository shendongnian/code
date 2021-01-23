    _SchemaProcessor = new ServerSchemaUtilityFramework.SchemaProcessor();
    _SchemaProcessor.SchemaProcessorMessage += new ServerSchemaUtilityFramework.SchemaProcessor.SchemaProcessorMessageEventHandler(sp_SchemaProcessorMessage);
    
    void sp_SchemaProcessorMessage(object sender, ServerSchemaUtilityFramework.MessageEventArgs e)
    {
        //Update the UI, if on background will need to (!this.Dispatcher.CheckAccess())     
    }
