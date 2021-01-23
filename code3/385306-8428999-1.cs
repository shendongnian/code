    using System;
    using System.Text.RegularExpressions;
    
    class Calc {
        static void Main(){
            int? answer = null;
            String equation = Console.ReadLine();
            Console.WriteLine("your equation is {0}", equation);
            if(Regex.IsMatch(equation, @"^[0-9\.\*\-\+\/\(\) ]+$")){
                answer = (int)BLUEPIXY.Math.Evaluate(equation);
            }
            Console.WriteLine("answer is {0}", answer);
        }
    }
