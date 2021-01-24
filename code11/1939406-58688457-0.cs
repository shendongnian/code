    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form1 formA = new Form1();       //Instantiate form 
        formA.Size = new Size(40, 40);   //Assign size to it
        Application.Run(formA);          //Display the form                                     
    }
