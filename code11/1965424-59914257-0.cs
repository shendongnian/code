    static void Main()
    {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
    
         var mainForm = new MTMainForm();
         TextWriter wrt = mainForm.GetWriter();
         Console.SetOut(wrt);
    
         _presenter = new MTMainPresenter(mainForm);
    
         Application.Run(mainForm);
    }
