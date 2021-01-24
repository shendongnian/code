    [HttpPost]
    [Route("api/send")]
    [DisableRequestSizeLimit] 
    public async Task<long> CreateAsync(MyClass obj) {
    {
      var file=this.Request.Form.Files[0];  //there's only one in our form
      using(StreamReader reader=new StreamReader(file))
      {
        var data=await reader.ReadToEndAsync();
        Console.WriteLine("File Content:"+data);
        Console.WriteLine("{ Field1 :"+obj.Field1.ToString()+",Field2:"+obj.Field2.ToString()+"}");
      }
      
    }
