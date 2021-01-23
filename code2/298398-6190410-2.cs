     class Program
     {
         MyForm myForm = new MyForm();
         ....
         myForm.MyFunction(); //call here
     }
     public partial class MyForm: Form
     {
         ....
         public int MyFunction() {...}
     }
