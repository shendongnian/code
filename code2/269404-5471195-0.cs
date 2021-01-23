    using System.Text.RegularExpressions;
    class Program {
        static void Main() {
            string expression = "(UI$.SlNo-UI+UI$.Task)-(UI$.Responsible_Person*UI$.StartDate) ";
            string replaced = Regex.Replace(expression, @"([\w\$\.]+)", " [ $1 ] ");
        }
    }
