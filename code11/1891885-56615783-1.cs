using System;
public class MainClass {
  public static void Main (string[] args) {
        int year;
        double deposited;
        double interestRate;
        Console.Write("Enter the amount of deposited: ");
        deposited = double.Parse(Console.ReadLine());
        Console.Write("Enter the number of years: ");
        year = int.Parse(Console.ReadLine());
        Console.Write("Enter the interest rate as a percentage of 1.0: ");
        interestRate = double.Parse(Console.ReadLine());
        Console.WriteLine("Year\t Balance");
        for(int i = 0; i < year; i++){
          var balance = deposited + (deposited * interestRate * (i + 1));
          Console.WriteLine("{0}\t\t{1}", (i + 1), balance);
        }
  }
}
Note: to calculate 1% interest rate, input "0.01", for 10%, "0.1" and for 100% "1.0" and so on.
