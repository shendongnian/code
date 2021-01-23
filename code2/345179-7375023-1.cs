In order to close the form you need to have a link to this form. The easiest way to do so is to add a new property to the Program object in your program that is static and available everywhere. Just modify your Program.cs file to make the Program class public and to add the appropriate reference:
    public static class Program
    {
        ///This is your splash screen
        public static Form1 MySplashScreen = new Form1();
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// This is how you run your main form
            Application.Run(MySplashScreen);
        }
    }
