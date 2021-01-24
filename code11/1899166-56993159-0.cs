    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           //snipped for brevity. See OP for full implementation  
           IsAllNullOrEmpty(args);
           ValidateAttributes(parameter, args, context.ModelState);
           
        }
    }
    public void IsAllNullOrEmpty(object myObject)
    {
       //Get the object so we don't have to keep calling reflection
       var obj = myObject.GetType();
      //Get a count of how many properties there are
      var propCount = obj.GetProperties().Count();
      var areAllNullOrEmpty = obj.GetProperties()
      .Select(pi => pi.GetValue(myObject))
      .Count(value => value == null);
      if (areAllNullOrEmpty == propCount)
      { throw new BadRequestException("The request body failed model validation."); }
    }
