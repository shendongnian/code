    // load from websites based on pool numbers in list
    var list = new List<string> { "510299", "510300"};
    foreach (var poolNumber in list)
    {
        XElement tags=XElement.Load("http://fapt.efanniemae.com/epooltalk-hvd/pool.xml?type=XML&pn=" + poolNumber + ".XML");
        XNamespace p = tags.GetDefaultNamespace();
    
        // export process
     
        XElement pool = tags.Element(p + "Pool");
        Console.WriteLine("Pool Num |" + pool.Element(p + "PoolNumber").Value);
        Console.WriteLine("CUSIP |" + pool.Element(p + "CUSIP").Value);
        Console.WriteLine("PoolPrefix |" + pool.Element(p + "PoolPrefix").Value);
        Console.WriteLine("Orig. Bal |" + pool.Element(p + "OriginalSecurityBalance").Value);
        Console.WriteLine("Orig. Term |" + pool.Element(p + "WeightedAverageOrigLoanTerm").Value);
        Console.WriteLine("Remain Term |" + pool.Element(p + "WAMnthsRemainingToAmortization").Value);
        Console.WriteLine("WALA |" + pool.Element(p + "WeightedAverageLoanAge").Value);
        Console.WriteLine("Net Rate |" + pool.Element(p + "CurrentAccrualRate").Value);
        Console.WriteLine("WA Margin |" + pool.Element(p + "WeightedAverageLoanMarginRate").Value);
        Console.WriteLine("SubType |" + pool.Element(p + "SubType").Value);
        Console.WriteLine("Updated CAP |" + pool.Element(p + "UpdatedCap").Value);
        Console.WriteLine("Issue Date |" + pool.Element(p + "IssueDate").Value);
        Console.WriteLine("Maturity Date |" + pool.Element(p + "MaturityDate").Value);
        Console.WriteLine("Rate Adj Freq |" + pool.Element(p + "RateAdjustmentFrequency").Value);
        Console.WriteLine("Period Cap |" + pool.Element(p + "PerAdjustmentCap").Value);
        Console.WriteLine("Pymt Chg Freq |" + pool.Element(p + "PaymentChangeFrequency").Value);
        Console.WriteLine("WA MTR |" + pool.Element(p + "WeightedAverageMonthsToRoll").Value);
        Console.WriteLine("WA CAP |" + pool.Element(p + "WeightedAverageCap").Value);
        
        var poolFactors = pool.Element(p + "PoolFactors");
        var months = poolFactors.Descendants(p + "Month")
                                .Select(m => m.Value);
        Console.WriteLine("Months |" + String.Join(", ", months.ToArray()));
        
        var wacs = poolFactors.Descendants(p + "WAC")
                              .Select(wac => wac.Value);
        Console.WriteLine("WAC |" + String.Join(", ", wacs.ToArray()));
        
        var wams = poolFactors.Descendants(p + "WAM")
                              .Select(wam => wam.Value);
        Console.WriteLine("WAM |" + String.Join(", ", wams.ToArray()));
        
        var factors = poolFactors.Descendants(p + "Factor")
                                 .Select(f => f.Value);
        Console.WriteLine("Factor |" + String.Join(", ", factors.ToArray()));
        
        Console.WriteLine();
    }
