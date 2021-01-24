        public class HomeController : Controller
        {
            private readonly IMapper _mapper;
            private readonly ApplicationDbContext _context;       
            public HomeController(IMapper mapper
                , ApplicationDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }        
            public async Task<IActionResult> Index()
            {
                CreatePostRequestDTO createPostRequestDTO = new CreatePostRequestDTO {
                    Body = "B1",
                    UserId = 1,
                    PostItems = new List<PostItemDTO> {
                        new PostItemDTO { AttachmentId = 1, TaggedUsers = new List<PostItemTagDTO>{
                            new PostItemTagDTO{ UserId = 1, X = 1, Y= 11  }
                        } }
                    }
                };
                var post = _mapper.Map<Post>(createPostRequestDTO);
                await _context.AddAsync(post);
                await _context.SaveChangesAsync();            
                return View();
            }        
        }
