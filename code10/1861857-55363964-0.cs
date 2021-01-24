    using System;
    using System.Windows.Forms;
    
    namespace BissonnetteMessageBox
    
    {
    internal class Program
    {
        private static void Main(string[] args)
        {
            int oddNumCount = 0;
            int smallNum = 0;
            int largeNum = 0;
            Random randNum = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int num = randNum.Next(100000);
                int remain = num % 2;
                if (remain != 0)
                {
                    oddNumCount++;
                }
                if (num < smallNum)
                {
                    smallNum = num;
                }
                else if (num > largeNum)
                {
                    largeNum = num;
                }
            }
            MessageBox.Show("the Number of odd numbers generated: " + oddNumCount +
                "\nSmallest number was: " + smallNum +
                "\nLargerst number was: " + largeNum, "random number generation results");
        }
    }
    }
