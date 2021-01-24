public class CheckboxViewModel
{
   private bool _checkboxValue;
   public bool CheckboxValue
   {
      get
      {
         return _checkboxValue;
      }
      set
      {
         _checkboxValue = value;
         RaisePropertyChanged(nameof(CheckboxValue));
      }
   }
}
Make sure you have two-way binding in checkbox view to that property
BTW - RaisePropertyChanged at setter of MyCollection raises event with wrong property name in you example.
