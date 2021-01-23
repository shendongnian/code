      using System;                                                              
      using System.Collections.Generic;                                          
      using System.ComponentModel;                                                
      using System.Data; System.Drawing;                                         
      using System.IO;                                                           
      using System.Text; System.Windows.Forms;                                   
      using System.Management;                                                   
      using System.Management.Instrumentation;                                    
                                                                           
 
                                                                            
     private void print(ref DirectoryInfo tempDir)                               
     {                                                                          
       try                                                                    
       {                                                                       
        foreach(FileInfo file in tempDir.GetFiles("*.pdf"))                 
        {                                                                   
            file.CopyTo("\\\\XYZ\\Phaser77\\" + file.Name);                 
        }                                                                   
       }                                                                      
       catch(Exception ee){ }                                                  
     }       
