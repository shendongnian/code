    public class ErrorInfo{
    public string Name { get; set; }
    public string FormatErrorMessage { get; set; }    
    public ErrorInfo(string name, string formatErrorMessage){
        Name = name;
        FormatErrorMessage = formatErrorMessage;
        
     }
    }
