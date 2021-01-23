    var c2 = new Class2 
                    { 
                      code = 3; 
                      Class1 = new Class1 
                      {
                          field1 = 7; 
                          field2 = "class 1"
                      }
                    };
    
    var fields = c2.GetType().GetFields();
    var field = fields.Where(fi=>fi.Name == "classRef").FirstOrDefault();
    Assert.True(field != null);
    var value = field.GetValue(c2) as Class1;
    
    Assert.True(value != null);
    Assert.True(value.field1 == 7);
    Assert.True(value.field2 == "class 1");
