    public static IEnumerable<TestCaseData> CountEqualsZeroAndHouseGrossIsGreaterTestCases
    {
	    get
	    {
		    yield return new TestCaseData(report, report.Merchants[4268435971532164].LineItem["EBTPerItem"], 4268435971532164, "EBTPerItem").SetName("ReportMerchantsLineItem");
		    yield return new TestCaseData(report, report.Merchants[5461324658456716].AggregateTotals, 5461324658456716, "WirelessPerItem").SetName("ReportMerchantsAggregateTotals");
		    yield return new TestCaseData(report, report.AggregateTotals, null, "AggregateTotals").SetName("ReportAggregateTotals");
		    yield return new TestCaseData(report, report.AggregateTotals.LineItem["WirelessPerItem"], null, "WirelessPerItem").SetName("ReportAggregateTotalsLineItem");
	    }
    }
    [TestCaseSource("CountEqualsZeroAndHouseGrossIsGreaterTestCases")]
    public void DoSanityCheck_WithCountEqualsZeroAndHouseGrossIsGreater_TestCase_SetsWarning(Reports.ResidualsReport report, Reports.LineItemObject container, long? mid, string field)
    {
	    container.ItemCount = 0;
	    container._volume = 0;
	    container._houseGross = 1;
	    
	    report.DoSanityCheck();
    
	    Assert.IsTrue(report.FishyFlag);
	    Assert.That(report.DataWarnings.Where(x=> x is Reports.WarningObjects.ImbalancedVariables && x.mid == mid && x.lineitem == field).Count() > 0);
    }
