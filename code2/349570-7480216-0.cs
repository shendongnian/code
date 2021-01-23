    interface IView
    {
         bool AskUser(string question);
    }
    class SomeClass
    {
         IView _View;
         public SomeClass(IView view)
         {
            _View = view;
         }
         public void SomeLogic()
         {
              if (someCondition && !_View.AskUser("continue?"))
                   return;
         }
    }
