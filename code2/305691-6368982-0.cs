    // GET: /reports/get/?type=spending
    public Controller Reports
    {
        public ActionResult Get(string typeName)
        {
            Type typeOfController;
            object instanceOfController;
            
            try
            {
                typeOfController = System.Reflection.Assembly.GetExecutingAssembly().GetType(name: typeName, throwOnError: true, ignoreCase: true)
                instanceOfController = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(typeName: typeName, ignoreCase: true);
            }
            catch(Exception ex)
            {
                // Controller not found
                return View("InvalidTypeName");
            }
            
            ActionResult result = null;
            
            try
            {
                result = typeOfController.InvokeMember("Index", System.Reflection.BindingFlags.InvokeMethod, null, instanceOfController, null)as ActionResult;
            }
            catch(Exception ex)
            {
                // Perhaps there was no parametersless Index ActionMethod
                // TODO: Handle exception
            }
            
              return result;
        }
    }
