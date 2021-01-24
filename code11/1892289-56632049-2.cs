    [Test]
    public void CompareVariables()
    {
       if (string.Equals(serialNumberInfo, serialNumberReport))
       {
          Console.WriteLine($"{serialNumberInfo} and {serialNumberReport} are a match! Proceed!");
       }
       else
       {
            Console.WriteLine($"{serialNumberInfo} and {serialNumberReport} don't match! Cancel test!");
            return;
       }
       // The rest of your tests
