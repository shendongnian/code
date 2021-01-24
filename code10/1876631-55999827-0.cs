        public class MyBadRequestObjectResult : BadRequestObjectResult, IClientErrorActionResult
        {
            public MyBadRequestObjectResult() : base((object)null)
            {
            }
            public MyBadRequestObjectResult(object error) : base(error)
            {
            }
        }
