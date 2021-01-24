c#
public class Version {
  public int _Major {get; set;}
  public int _Minor{get; set;}
  public int _Build{get; set;}
  public int _Revision{get; set;}
}
public class HttpReturnMessage {
  public Version Version {get; set;}
  public int StatusCode {get; set;}
  public string ReasonPhrase {get; set;}
  public string[] Headers {get; set;}
  public object RequestMessage {get; set;}
  public bool IsSuccessStatusCode {get; set;}
}
and create the item in the controller and return it:
c#
HttpReturnMessage message = new HttpReturnMessage {
  Version = new Version {
    _Major= 1,
    _Minor = 1,
    _Build = 1,
    _Revision = 1
  },
  StatusCode = 300, 
...
};
and return this as json
