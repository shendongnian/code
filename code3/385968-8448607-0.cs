    public class Settings     
    { 
         public static readonly string fileName = "config.ini"; 
         private IConfigSource src;
         private IConfigSource Src
         {  
             get  
             { 
                  CreateIfNotExists();  
                  return src; 
             }  
         }    
         public void test1()   
         {
             //var src = new IniConfigSource(fileName); 
             Src.Configs["DATA"].Set("baa", "haaaaee");      
             Src.Save();     
         }      
         public void test2()  
         { 
             Src.Configs["DATA"].Set("baa", "haaaaee");
             Src.Save();         
         }    
         public Stream CreateIfNotExists()     
         { 
             if (!File.Exists(fileName))         
             {
                  Stream file = File.Create(fileName);
                  src = new IniConfigSource(fileName);
                  return file;        
             } 
             src = null;
             return null;    
          }
      } 
