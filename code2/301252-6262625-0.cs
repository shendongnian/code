    public class MenuItem
    {
        public string Name { get; set; }
        public RouteValueDictionary RouteValues
        {
            get
            {
                return new RouteValueDictionary(
                    new {
                        controller = "Pages",
                        action = this.Name
                    });
            }
        }
    }
