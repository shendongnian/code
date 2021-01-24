        using System;
        namespace VMLayer
        {
          public class ViewModelLocator
          {
            static ViewModelLocator()
            {
              SimpleIoc.Default.Register<DialogVM>(true);
            }
    
            public static DialogVM MyDialog => SimpleIoc.Default.GetInstance<DialogVM>();
          }
        }
