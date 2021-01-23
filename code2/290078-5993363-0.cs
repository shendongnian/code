    static class Program
    {
      static Form NextForm=new frmLogin();   // or whatever your first form is
      static public void SetNext(Form next) { NextForm=next; }
      static void Main()
      { 
        while(NextForm!=null)
        {
          Form _next=NextForm;
          NextForm=null;      // so it closes at the end
          Application.Run(NextForm);
        }
      }
    }
