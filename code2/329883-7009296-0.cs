    double dTotalICostMM = 0.0, dTotalDCostMM = 0.0;
    decimal dCost = Decimal.Zero, iCost = Decimal.Zero;
    using (XmlReader reader = XmlReader.Create(strFileName))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == "episodeCost")
            {
                dCost = Convert.ToDecimal(reader.GetAttribute("dCost"));
                iCost = Convert.ToDecimal(reader.GetAttribute("iCost"));
            }
        }
        // Add each cost to its total for the month
        dTotalDCostMM += (double)dCost;
        dTotalICostMM += (double)iCost;
    }
