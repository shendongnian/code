    var mySum_ClassGroupProductLevel =
                    from s in ReportData.myStands
                    join p in ReportData.myPlots on s.ID equals p.StandID
                    join t in ReportData.myTrees on p.ID equals t.PlotID
                    group t by new { s.Strata, p.ID, 
                        ClassName = useClassName ? t.ClassName : string.Empty, 
                        GroupName = useGroupName ? t.GroupName : string.Empty, 
                        ProductName = useProductName ? t.ProductName : string.Empty }
                        into g
                    select new
                    {}
