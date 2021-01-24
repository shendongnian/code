    public class ClassroomsController : Controller {
    
        // C O N S T R U C T O R
        public ClassroomsController() {
            //...
        }
    
        [HttpGet("Classrooms/API01/{userId}")]
        public IActionResult API01(string userId) {
            string requestedUserId = userId;
    
            //...
        }
    
        [HttpGet("Classrooms/API02/{userId}")]
        public IActionResult API02(string userId) {
            string requestedUserId = userId;
    
            //...
        }
    }
