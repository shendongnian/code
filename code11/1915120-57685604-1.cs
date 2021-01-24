    public class MyController
    {
        private readonly IMapper mapper;
       
        public MyController(IMapper mapper)
        {
            this.mapper = mapper;
        }
       
        // Then in any of your methods:
        [HttpGet]
        public IActionResult MyMethod()
        {
            var objectsToMap = details.Student; // This is an array of Student type.
            var mappedObjects = this.mapper.Map(objectsToMap); // This will be an array of ArrayOfStudents.
            // do what you will with the mapped objects.
        }
    }
