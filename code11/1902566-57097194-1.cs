         public class AuthorController : Controller{
             private readonly IMapper mapper;
             private readonly Context context;
               public AuthorController(IMapper mapper, Context context){
                     mapper =mapper;
                    //...context=context;
               }
               public IActionResult Details(int id){
                  var author = context.Author.Include(a=>a.Book)
                               .FirstOrDefault(a=>a.Id=id);
                 if(author==null) return NotFoun();
                 var authorDTO = mapper.Map<AuthorDTO>(author);
                 return View(authorDTO);
               }
         }
