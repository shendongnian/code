    public static bool IsJson(this string input){
        input = input.Trim();
        Predicate IsWellFormed = () => {
                 try {
                    JToken.Parse(input);
                 } catch {
                    return false;
                 }
                 return true;
        }
        return (input.StartsWith("{") && input.EndsWith("}") 
                || input.StartsWith("[") && input.EndsWith("]"))
               && IsWellFormed()
    }
