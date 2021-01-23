     public interface IForm
     {
        bool GetResult();
     }
     // form 2
     public partial class Form2 : Form, IForm (...)
     private bool Result;
     public bool GetResult()
     {
      return Result;
     }
     
     // form 1
     var form2 = new Form2();
     ((IForm)form2).GetResult();
     
