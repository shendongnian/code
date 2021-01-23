    class GreatInterface : IGreatInterface
    {
        // explicitly implement aMethodBeta() when called from interface reference
        object IGreatInterface.aMethodBeta(IAnInterface parameter)
        {
            // do whatever you'd do on IAnInterface itself...
            var newParam = parameter as SomeSubClass;
            if (newParam != null)
            {
                aMethodBeta(newParam);
            }
            // otherwise do some other action...
        }
        // This version is visible from the class reference itself and has the 
        // sub-class parameter
        public object aMethodBeta(SomeSubClass parameter)
        {
            // do whatever
        }
    }
