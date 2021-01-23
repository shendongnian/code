    namespace Program  
    {  
        public class MyClass  
        {  
             public static void Calling(Page page)  
             {  
                ContentPlaceHolder cph = page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
                if (cph == null)
                {
                      return;
                }
                PlaceHolder ph = cph.FindControl("PlaceHolder1") as PlaceHolder;
                if (ph != null)
                {
                    ph.Controls.Add(new TextBox());
                }
             }  
        }  
    }  
