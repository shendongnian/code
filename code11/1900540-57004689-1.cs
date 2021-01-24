    public class MyController
    {
        private readonly IMapper mapper;
       
        public MyController(IMapper mapper)
        {
           this.mapper = mapper;
        }
    
        public IActionResult MyMethod(ApiInputModelDTO input)
        {
           var inputModel = this.mapper.Map<ApiInputModel>(input);
           // Do what you want with it...
        }
    }
