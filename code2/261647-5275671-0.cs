    [WebGet(ResponseFormat=WebMessageFormat.Json, UriTemplate="GetComplexObject/{id}")]
    public MyComplexType GetComplexObject(int id){
      //do work to get your object
      return myObject;
    }
