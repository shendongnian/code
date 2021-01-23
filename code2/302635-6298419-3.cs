    public class Generator
    {
       
       private ITemplate _template;
       public Generator(ITemplate t)
       {
          _template = t;
    
       }
    
       public void Generate()
       {
           _template.Generate();
       }
    }
