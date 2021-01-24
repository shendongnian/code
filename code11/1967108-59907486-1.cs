    Program.cs
    ...
    static class Program
    {
        ...
        public static LoginForm mainForm;
        static void Main()
        {
            ....
            mainForm = new LoginForm();
            Application.Run(mainForm);
        }
    }
