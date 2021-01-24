       protected void Application_Start()
            {
                //other application_start code goes here
    
                ModelBinders.Binders.Add(typeof(double?), new DoubleModelBinder());
                ModelBinders.Binders.Add(typeof(double), new DoubleModelBinder());
            }
