    namespace System.ComponentModel.DataAnnotations
    {
        public class ChangeableRequired : RequiredAttribute
        {
           public bool Disabled { get; set; }
           public override bool IsValid(object value)
           {
              if (Disabled)
              {
                return true;
              }
              return base.IsValid(value);
           }
        }
    }
