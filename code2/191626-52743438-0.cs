    namespace LibBar
    {
      [AttributeUsage(AttributeTargets.Method)]
      public class AnswerAttribute : Attribute { }
      public interface IFoo
      {
        void Hello();
        int GetAnswer();
        object WhoAmI();
      }
    }
