    using Excel.FinancialFunctions;
    namespace ExcelXirr
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<double> valList =new List<double>();
                valList.Add(4166.67);
                valList.Add(-4166.67);
                valList.Add(-4166.67);
                valList.Add(-4166.67);
                List<DateTime> dtList = new List<DateTime>();
                dtList.Add(new DateTime(2014, 9, 1));
                dtList.Add(new DateTime(2014, 10, 1));
                dtList.Add(new DateTime(2014, 11, 1));
                dtList.Add(new DateTime(2014, 12, 1));
                double result = Financial.XIrr(valList, dtList);
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
