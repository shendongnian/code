    if (controllers != null && controllers.Any())
    {
         foreach (ControllerBase controllerBase in controllers)
         {
             builder.AddApplicationPart(controllerBase.GetType().Assembly);
         }
     }
