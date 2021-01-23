    [HttpPost]
    [Route("myRoute")]
    public object SomeApiControllerMethod([FromBody] dynamic args){
       var stringValue = args.MyPropertyName.ToString();
       //do something with the string value.  If this is an int, we can int.Parse it, or if it's a string, we can just use it directly.
       //some more code here....
       return stringValue;
    }
