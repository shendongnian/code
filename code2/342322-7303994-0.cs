    private string ErrorMessage(string input, string dataTypeExpected="string")   
    {
            switch (dataTypeExpected)
            {
                case "string": if (!string.IsNullOrEmpty(input))
                                return input;
                                break;
                case "int": 
                      int result=-1;
                      if (int.TryParse(input, out result))
                           return result.ToString();
                      else return "Error: value must be an integer";
               
             }                
             return "No value entered!";
     }
