    public class GridAttribute : GridActionAttribute, IActionFilter
      {
        private readonly IGridActionResultAdapterFactory adapterFactory;
    
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
          adapterFactory = DI.Current.Resolve<IGridActionResultAdapterFactory>();
        }
    
        protected override ActionResult CreateActionResult(object model)
        {
          return EFJsonResultGridActionFactory.Create(model, SerializationDepth);
        }
      }
    }
