    public class CustomRouteAttribute : Attribute, IRouteTemplateProvider
        {
            string serverKey = string.Empty;
    
            public CustomRouteAttribute()
            {
                string serverKey = "Your Key";
            }
    
            public string Template => $"api/{serverKey}/[controller]";
    
            public int? Order { get; set; }
    
            public string Name { get; set; }
        }
