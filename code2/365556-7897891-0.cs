       using System;
       using System.Drawing;
       using System.Drawing.Text;
       using System.Collections;
       using System.ComponentModel;
       using System.Windows.Forms;
       using System.Data;        
           
    
       public class Test{
            static void Main() 
            {
              InstalledFontCollection fonts = new InstalledFontCollection();
              for(int i = 0; i < fonts.Families.Length; i++)
              {
                Console.WriteLine(fonts.Families[i].Name);
              }
            }
          }
