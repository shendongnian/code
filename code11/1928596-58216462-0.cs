using System.Threading;
namespace yourNamespace
{
    static class Program
    {
        static void main()
        {
            Thread thread = new thread(Task);
            thread.Start();
        }
        private void Task()
        {
            //What you want to do
        }
    }
}
