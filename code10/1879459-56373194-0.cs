    public SomeBaseType MyFunction()
    {
        return SomeFunction() ?? LocalMethod();
    
        SomeBaseType LocalMethod()
        {  
            // Do lots of other statements...
            return somethingElseThatIsADerivedTypeThatDoesntMatter;
        }
    }
