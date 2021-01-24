    void Main()
    {
    	const int ApplianceTypeID = 10;
    	var applianceModels = GetApplianceModels().XPathSelectElements("Model"); //.Dump();
    	var applianceTypeColumns = GetApplianceTypeColumns().Where(x => x.ApplianceTypeID == ApplianceTypeID); //.Dump();
    	
    	var uniqueColumns = Enumerable.Concat(
    		"Action,ManufacturerCode".Split(','),
    		applianceTypeColumns
    			.Where(at => at.ApplianceColumnUnique)
    			.Select(at => at.ApplianceColumnName)
    	);
    	
    	var query = applianceModels
    		.GroupBy(
    			model => uniqueColumns.Select(columnName => model.Element(columnName)?.Value).ToArray(),
    			new LambdaComparer<string[]>((a, b) => a.SequenceEqual(b), x => x.Aggregate(13, (hash, y) => hash * 7 + y?.GetHashCode() ?? 0))
    		)
    		.Select(g => new { g.Key, Duplicates = g.Select(x => x.Element("CECID")?.Value) });
    		//.Dump();
    }
    
    // Define other methods and classes here
    XElement GetApplianceModels()
    {
    	return XElement.Parse(
    @"<ApplianceModels xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ApplianceType=""IceMakers"">
        <Model>
            <ReferenceNumber>201877149</ReferenceNumber>
            <Action>C</Action>
            <Brand>4564</Brand>
            <ModelNumber>1234212</ModelNumber>
            <EquipmentType>A</EquipmentType>
            <CoolingType>W</CoolingType>
            <IceType>C</IceType>
            <IceMakerProcessType>B</IceMakerProcessType>
            <TestLabCode>ARN3190</TestLabCode>
            <ManufacturerCode>ARN2396</ManufacturerCode>
            <HarvestRateLbs24Hr>56</HarvestRateLbs24Hr>
            <EnergyCons_kWhPer100Lbs>4.00</EnergyCons_kWhPer100Lbs>
            <WaterCons_galPer100Lbs>12</WaterCons_galPer100Lbs>
            <IceHardnessAdjustmentFactor xsi:nil=""true"" />
            <RegulatoryStatus>I</RegulatoryStatus>
            <CECID>d579ae7a-f3f7-4627-a3f1-f17b23aa28e3</CECID>
        </Model>
        <Model>
            <ReferenceNumber>201877143</ReferenceNumber>
            <Action>C</Action>
            <Brand>4564</Brand>
            <ModelNumber>12342</ModelNumber>
            <EquipmentType>A</EquipmentType>
            <CoolingType>W</CoolingType>
            <IceType>C</IceType>
            <IceMakerProcessType>B</IceMakerProcessType>
            <TestLabCode>ARN3190</TestLabCode>
            <ManufacturerCode>ARN2396</ManufacturerCode>
            <HarvestRateLbs24Hr>56</HarvestRateLbs24Hr>
            <EnergyCons_kWhPer100Lbs>4.00</EnergyCons_kWhPer100Lbs>
            <WaterCons_galPer100Lbs>12</WaterCons_galPer100Lbs>
            <IceHardnessAdjustmentFactor xsi:nil=""true"" />
            <RegulatoryStatus>I</RegulatoryStatus>
            <CECID>94c6d6e6-5b6a-4f45-a7ff-70a64e50e4e6</CECID>
        </Model>
        <Model>
            <ReferenceNumber>201877152</ReferenceNumber>
            <Action>C</Action>
            <Brand>4564</Brand>
            <ModelNumber>1231114234</ModelNumber>
            <EquipmentType>A</EquipmentType>
            <CoolingType>W</CoolingType>
            <IceType>C</IceType>
            <IceMakerProcessType>C</IceMakerProcessType>
            <TestLabCode>ARN3190</TestLabCode>
            <ManufacturerCode>ARN2396</ManufacturerCode>
            <HarvestRateLbs24Hr>81</HarvestRateLbs24Hr>
            <EnergyCons_kWhPer100Lbs>1.10</EnergyCons_kWhPer100Lbs>
            <WaterCons_galPer100Lbs>12</WaterCons_galPer100Lbs>
            <IceHardnessAdjustmentFactor>4.45</IceHardnessAdjustmentFactor>
            <RegulatoryStatus>I</RegulatoryStatus>
            <CECID>d97a603c-1836-43a3-b564-ab8d1bdec65f</CECID>
        </Model>
    </ApplianceModels>");
    }
    IEnumerable<(int ApplianceTypeID, bool ApplianceColumnUnique, string ApplianceColumnName)> GetApplianceTypeColumns()
    {
    	var data =
    @"ApplianceTypeID       ApplianceColumnUnique        ApplianceColumnName
    10                    0                            ReferenceNumber
    10                    1                            Brand
    10                    1                            ModelNumber
    10                    0                            EquipmentType
    10                    0                            CoolingType
    10                    0                            IceType
    10                    0                            IceMakerProcessType
    10                    0                            HarvestRateLbs24Hr
    10                    0                            EnergyCons_kWhPer100Lbs
    10                    0                            WaterCons_galPer100lbs
    10                    1                            RegulatoryStatus";
    	return Regex.Matches(data, @"^(\d+)\s+(\d+)\s+(\w+)", RegexOptions.Multiline)
    		.Cast<Match>()
    		.Select(x => 
    		(
    			/*ApplianceTypeID = */int.Parse(x.Groups[1].Value),
    			/*ApplianceColumnUnique = */int.Parse(x.Groups[2].Value) != 0,
    			/*ApplianceColumnName = */x.Groups[3].Value
    		));
    }
    
    class LambdaComparer<T> : IEqualityComparer<T>
    {
    	private readonly Func<T, T, bool> equals;
    	private readonly Func<T, int> getHashCode;
    	
    	public LambdaComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
    	{
    		this.equals = equals;
    		this.getHashCode = getHashCode;
    	}
    	
    	public bool Equals(T x, T y) => equals(x, y);
    	public int GetHashCode(T obj) => getHashCode(obj);
    }
