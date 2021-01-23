    // Wild guess at the class name, but you get the idea
    private void InitializeTotals(AggregateItem item)
    {
        item.ItemCount = 0;
        item._volume = 0;
        item._houseGross = 1;
    }
    [Test]
    public void DoSanityCheck_WithCountEqualsZeroAndHouseGrossIsGreater_InMerchantAggregateTotals_SetsWarning()
    {
        InitializeTotals(report.Merchants[5461324658456716].AggregateTotals);
        report.DoSanityCheck();
        Assert.IsTrue(report.FishyFlag);
        Assert.That(report.DataWarnings.Where(x => x is Reports.WarningObjects.ImbalancedVariables && x.mid == 5461324658456716 && x.lineitem == "AggregateTotals").Count() > 0);
    }
    [Test]
    public void DoSanityCheck_WithCountEqualsZeroAndHouseGrossIsGreater_InAggregateTotals_SetsWarning()
    {
        InitializeTotals(report.AggregateTotals);
        report.DoSanityCheck();
        Assert.IsTrue(report.FishyFlag);
        Assert.That(report.DataWarnings.Where(x => x is Reports.WarningObjects.ImbalancedVariables && x.mid == null && x.lineitem == "AggregateTotals").Count() > 0);
    }
    [Test]
    public void DoSanityCheck_WithCountEqualsZeroAndHouseGrossIsGreater_InAggregateTotalsLineItem_SetsWarning()
    {
        InitializeTotals(report.AggregateTotals.LineItem["WirelessPerItem"]);
        report.DoSanityCheck();
        Assert.IsTrue(report.FishyFlag);
        Assert.That(report.DataWarnings.Where(x => x is Reports.WarningObjects.ImbalancedVariables && x.mid == null && x.lineitem == "WirelessPerItem").Count() > 0);
    }
