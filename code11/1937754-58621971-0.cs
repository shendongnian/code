    public class MyRouteView : RouteView
    {
       // Define necessary properties
            [Parameter]
            public Type ActivatedLayout { get; set; }
    
            [Parameter]
            public Type DeactivatedLayout { get; set; }
    
          // Add more code to do the work of activating and deactivating the layout
    }
