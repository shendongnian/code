    @code{
    
        public string ID { get; set; }
    
        protected override void OnParametersSet()
        {
            // pull out the "ID" parameter from the route data
            object id = null;
            if ((this.Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("ID", out id) == true)
            {
                ID = id?.ToString();
            }
           
        }
    }
