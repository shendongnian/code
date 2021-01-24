    public class BaseModel
    {
        public int Id { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class Question : BaseModel
    {
        public string QuestionText { get; set; }
        public string Type { get; set; }
    }
    //Startup.cs
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
                );
            });
    //Home Controller
        public IActionResult Test()
        {
            _applicationDbContext.Questions.Add(new Question
            {
                Id = 0, //Changing this value affects the behaviour of the application
                QuestionText = "Question text"
            });
            _applicationDbContext.SaveChanges();
            return View(_applicationDbContext.Questions.ToList());
        }
