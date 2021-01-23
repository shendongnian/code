    public class ConsoleClass
    {
        public void SomeMethod()
        {
            ActionClass1 class1 = new ActionClass1();
            class1.DisplayMessage = this.Print;
        }
        private void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
