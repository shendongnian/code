    public void Invoke(IPipelineContext context)
    {
         foreach (handler in _handlers)
         {
            try
            {
                 handler.Process(context);
            }
            catch (Exception err)
            {
                //abort or continue with the next handler?
            }
         }
    }
