       class foo
        {
            public string field1 {get;set;}
            public string field2 { get; set; }
                            
            public void SetValueForAllString( string value)
            {
                var vProperties = this.GetType().GetProperties();
                foreach (var vPropertie in vProperties)
                {
                    if (vPropertie.CanWrite 
                        && vPropertie.PropertyType.IsPublic 
                        && vPropertie.PropertyType == typeof(String))
                    {
                        vPropertie.SetValue(this, value, null);
                    }
                }
        
            }
        }
    
        foo f = new foo() { field1 = "field1", field2 = "field2" };
                    f.SetValueForAllString("foobar");
                    var field1Value = f.field1; //"foobar"
    
                 var field2Value = f.field2; //"foobar"
