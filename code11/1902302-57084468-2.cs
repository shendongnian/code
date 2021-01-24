    public class ResponseObject<T> {
        public ResponseStatus Status { get; set; }
        public T Value { get; set; }
    
        public ActionResult ToActionResult() {
            switch (Status) {
                case ResponseStatus.Ok:
                   return new OkObjectResult(this);
    
                case ResponseStatus.BadRequest:
                   return new BadRequestObjectResult(this);
    
                // ...
            }
        }
    }
