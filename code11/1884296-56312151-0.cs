    [HttpGet("{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
        }
    
        [HttpGet("User/{userId}")]
        public IActionResult GetUserTask([FromRoute] string userId)
        {
        }
