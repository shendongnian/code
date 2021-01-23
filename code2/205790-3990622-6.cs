    Activity IActivityTemplateFactory.Create(System.Windows.DependencyObject target)
    {
        return new Child
        {
            InputText = new InArgument<string>(
                new VisualBasicValue<string>(Parent.InputTextVariable)),
            // the following demonstrates what NOT to do in the Create method. 
            // this BREAKS your ActivityFunc, which will ALWAYS return default(T)
            // DO NOT SET Result AT ANY TIME OR IN ANY PLACE
            // BEGIN ERROR
            Result = new OutArgument<string>()
            // END ERROR
        };
    }
