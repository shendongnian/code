    var item = new GenericType(){ 
         TypeName = "GenericTypeDemo.Cat, GenericTypeDemo",
         JsonString = "{CatName:'Test'}";
     }
    var genericObject= ToObject(item); // return it to the javascript
    Cat cat = genericObject as Cat; // Cast it if you want
