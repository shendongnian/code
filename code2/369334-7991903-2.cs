    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using Microsoft.SharePoint;   
    namespace ConsoleApplication 
    {     
    class Program     
    {         
    static void Main(string[] args)         
    {             
        using (SPSite spSite = new SPSite("http://yoururl"))            
        {                 
              using (SPWeb spWeb = spSite.RootWeb)   
              {                     
                //perform the code to clone the group here
              }          
        }                  
     }    
     } 
    }
