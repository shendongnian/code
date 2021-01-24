     [ApiController]
     public class ShowNote : Controller
     {
      private readonly INoteRepository _note;
      public ShowNote(INoteRepository note)
        {
            _note = note;
        }
    }
