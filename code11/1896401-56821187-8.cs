    var item = new DynamicType(){ 
         TypeName = "DynamicTypeDemo.Cat, DynamicTypeDemo",
         JsonString = "{CatName:'Test'}"; // And for a list "[{CatName:'Test'}]"
     }
    object dynamicObject= ToObject(item); // return it to the javascript
    Cat cat = dynamicObject as Cat; // Cast it if you want
