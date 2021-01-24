    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase {
    
      [HttpGet("GetPostComments/{id}")]
      public async Task<ActionResult<IEnumerable<Comment>>> GetSpecificComment(int id)
      {
          var comment = await _context.Comment.Where(c => c.PostId == id).ToListAsync();
          if (comment == null)
          {
             return NotFound();
          }
    
          return comment;
     }
    
    }
