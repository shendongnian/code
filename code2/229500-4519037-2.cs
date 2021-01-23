    namespace Program  
    {  
        public class MyClass  
        {  
             public static void Calling(Page page)  
             {  
                  Textbox txt = new Textbox();
                  PlaceHolder ph = page.FindControl("PlaceHolder1") as PlaceHolder;
                  if (ph != null)
                  {
                        ph.Controls.Add(txt);
                  }
             }  
        }  
    }  
