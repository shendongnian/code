    public class MyFileStreamResult : FileStreamResult 
    {
        // [.. constructors here ..]
        public override void ExecuteResult(ControllerContext context) 
        {
            base.ExecuteResult(context);
            
            // do something here
        }
    }
