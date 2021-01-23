     using Lib2Settings = PC.MyCompany.Project
     public class foo {
         public somemethod() {
             var value1 = caLibClient.Settings.MyProperty1  // fully-qualified
             var value2 = Lib2Settings.MyProperty2          // utilizing the using keyword
         } 
     }
