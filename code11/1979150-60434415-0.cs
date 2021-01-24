        class Something {  
          public string Cuota{ get; set; }  
        }
        
        Something yourObject = new Something(){  
          Cuota= "blablabla"
        };
    
        string json = JsonConvert.SerializeObject(yourObject);
    
      
    
      
