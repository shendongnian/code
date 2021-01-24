         public class AuthorController : Controller{
             private readonly IMapper mapper;
             private readonly Context context;
               public AuthorController(IMapper mapper, Context context){
                     mapper =mapper;
                    //...context=context;
               }
               public IActionResult Index(){
                  var authors = context.Author.Include(a=>a.Book).ToList();
                 var authorDTOs = mapper.Map<List<AuthorDTO>>(authors);
                 return View(authorDTOs);
               }
         }
