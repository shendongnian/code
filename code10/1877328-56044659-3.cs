    string sDatabaseName = "YourDatabaseName";
    string sCubeName = "YourCubeName";
    string sMeasureGroupName = "YourMeasureGroupName";
    Microsoft.AnalysisServices.Server s = new Microsoft.AnalysisServices.Server();
    s.Connect("Data Source=localhost");
    Microsoft.AnalysisServices.Database db = s.Databases.GetByName(sDatabaseName);
    Microsoft.AnalysisServices.Cube c = db.Cubes.GetByName(sCubeName);
    Microsoft.AnalysisServices.MeasureGroup mg = c.MeasureGroups.GetByName(sMeasureGroupName);
    Microsoft.AnalysisServices.AdomdClient.AdomdConnection conn = new Microsoft.AnalysisServices.AdomdClient.AdomdConnection(s.ConnectionString);
    conn.Open();
    foreach (Microsoft.AnalysisServices.Partition p in mg.Partitions)
    {
        Console.Write(p.Name + " - " + p.State + " - ");
        var restrictions = new Microsoft.AnalysisServices.AdomdClient.AdomdRestrictionCollection();
        restrictions.Add("DATABASE_NAME", db.Name);
        restrictions.Add("CUBE_NAME", c.Name);
        restrictions.Add("MEASURE_GROUP_NAME", mg.Name);
        restrictions.Add("PARTITION_NAME", p.Name);
        var dsAggs = conn.GetSchemaDataSet("DISCOVER_PARTITION_STAT", restrictions);
        var dsIndexes = conn.GetSchemaDataSet("DISCOVER_PARTITION_DIMENSION_STAT", restrictions);
        if (dsAggs.Tables[0].Rows.Count == 0)
            Console.WriteLine("ProcessData not run yet");
        else if (dsAggs.Tables[0].Rows.Count > 1)
            Console.WriteLine("aggs processed");
        else if (p.AggregationDesign == null || p.AggregationDesign.Aggregations.Count == 0)
        {
            bool bIndexesBuilt = false;
            foreach (System.Data.DataRow row in dsIndexes.Tables[0].Rows)
            {
                if (Convert.ToBoolean(row["ATTRIBUTE_INDEXED"]))
                {
                    bIndexesBuilt = true;
                    break;
                }
            }
            if (bIndexesBuilt)
                Console.WriteLine("indexes have been processed. no aggs defined");
            else
                Console.WriteLine("no aggs defined. need to run ProcessIndexes on this partition to build indexes");
        }
        else
            Console.WriteLine("need to run ProcessIndexes on this partition to process aggs and indexes");
    }
