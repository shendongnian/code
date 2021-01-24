    public List<Base> FormatOutput(ModelStateDictionary input)
        {
            List<Base> baseResult = new List<Base>();
            foreach (var modelStateKey in input.Keys)
            {
                var modelStateVal = input[modelStateKey];
                foreach (ModelError error in modelStateVal.Errors)
                {
                    Base basedata = new Base();
                    basedata.Status = StatusCodes.Status400BadRequest;
                    basedata.Field = modelStateKey; 
                    basedata.Message =error.ErrorMessage; // set the message you want 
                    baseResult.Add(basedata);
                }
            }
            return baseResult;
        }
     public class Base
    {
        public int Status { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
