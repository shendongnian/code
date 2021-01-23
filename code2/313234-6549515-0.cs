    public delegate void SchemaProcessorMessageEventHandler(object sender, MessageEventArgs e);
    public event SchemaProcessorMessageEventHandler SchemaProcessorMessage;
    
    protected virtual void OnSchemaProcessorMessage(MessageEventArgs e)
    {
        if (SchemaProcessorMessage != null)
        {
            SchemaProcessorMessage(this, e);
        }
    }
