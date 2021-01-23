    public class ConsoleClass
    {
        public void SomeMethod()
        {
            ActionClass1 class1 = new ActionClass1();
            class1.DisplayMessage = x => Console.WriteLine(x);
        }
    }
