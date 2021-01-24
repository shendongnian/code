c#
using System;
using System.Collections.Generic; 
public class Kata
{
public static int SquareDigits(int n) {
    string outputNums = "";
    foreach (char s in n.ToString()) {
        int i = Int32.Parse(s.ToString());
        double outputNum =  Math.Pow(i, 2);
        outputNums += Convert.ToString(outputNum);
    }
    return Convert.ToInt32(outputNums);
}
}
