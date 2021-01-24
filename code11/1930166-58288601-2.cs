`
using System;
using System.Collections.Generic;
namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            var rules = new List<IRule>() { new Rule1(), new Rule2(), new Rule3() };
            calc.Do(rules);
            Console.WriteLine(calc.GetTotal());
            Console.ReadKey();
        }
    }
    public interface IRule
    {
        float Calc();
    }
    public class Rule1 : IRule
    {
        int type = 1;
        string name = "Rule";
        public float Calc()
        {
            return 1 + 2 + type; // SAME
        }
    }
    public class Rule2 : IRule
    {
        int type = 2;
        string name = "Rule2";
        public float Calc()
        {
            return 1 + 2 + type; // SAME
        }
    }
    public class Rule3 : IRule
    {
        int type = 3;
        string name = "Rule3";
        public float Calc()
        {
            return 3 + 4 + type; // DIFFERENT
        }
    }
    public class Calculator
    {
        private float _total = 0;
        public void Do(List<IRule> ruleList)
        {
            foreach (var rule in ruleList)
            {
                _total += rule.Calc();
            }
        }
        public float GetTotal()
        {
            return _total;
        }
    }
}
`
