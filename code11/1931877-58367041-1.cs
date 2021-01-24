c#
using System;
using System.Collections.Generic; 
public class Kata
{
public static UInt64 SquareDigits(int n) {
    string outputNums = "";
    foreach (char s in n.ToString()) {
        UInt64 i = UInt64.Parse(s.ToString());
        double outputNum =  Math.Pow(i, 2);
        outputNums += Convert.ToString(outputNum);
    }
    return Convert.ToUInt64(outputNums);
}
}
knowing that a number multiplied by itself is always positive we can use UInt64 which is an Int64 but with only positive numbers.
