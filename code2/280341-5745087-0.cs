    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    ReportClass report = new CrystalReport1();
    report.SetParameterValue("companies", "Microsoft");
    //or use the overloaded value for an array as 2nd parameter
