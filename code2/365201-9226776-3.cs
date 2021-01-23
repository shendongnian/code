    public class GridAttribute : GridActionAttribute, IActionFilter
      {    
        /// <summary>
        /// Determines the depth that the serializer will traverse
        /// </summary>
        public int SerializationDepth { get; set; } 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GridActionAttribute"/> class.
        /// </summary>
        public GridAttribute()
          : base()
        {
          ActionParameterName = "command";
          SerializationDepth = 1;
        }
    
        protected override ActionResult CreateActionResult(object model)
        {    
          return new EFJsonResult
          {
           Data = model,
           JsonRequestBehavior = JsonRequestBehavior.AllowGet,
           MaxSerializationDepth = SerializationDepth
          };
        }
    }
