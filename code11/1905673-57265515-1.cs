    public List<Base> FormatOutput(ModelStateDictionary input)
        {
            List<Base> baseResult = new List<Base>();
            foreach (var modelState in input.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    Base basedata = new Base();
                    basedata.Error = StatusCodes.Status400BadRequest;
                    basedata.Message =error.ErrorMessage; //Enum.Parse<APIResponseMessageEnum>(code.ToString(), true); // (enum of code get value from language)
                    baseResult.Add(basedata);
                }
            }
            return baseResult;
        }
    public class Base
    {
        public int Error { get; set; }
        public string Message { get; set; }
    }
