    Public Overrides Function DataReaderToBusinessObject(ByVal reader As System.Data.IDataReader) As IPosition
        Dim res As IPosition = New Position
        res.ItemDate = reader.GetDateTime(reader.GetOrdinal("Date"))
        res.Strategy = reader.GetString(reader.GetOrdinal("Strategy"))
        res.SubStrategy = reader.GetString(reader.GetOrdinal("SubStrategy"))
        res.BrokerPrime = reader.GetString(reader.GetOrdinal("BrokerPrime"))
        res.BrokerExecuting = reader.GetString(reader.GetOrdinal("BrokerExecuting"))
        res.AccountName = reader.GetString(reader.GetOrdinal("AccountName"))
        res.ExpectedLoss = reader.GetDouble(reader.GetOrdinal("Expected_Loss"))
        res.RiskNotional = reader.GetDouble(reader.GetOrdinal("Risk_Notional"))
        res.ModelDelta = reader.GetDouble(reader.GetOrdinal("Model_Delta"))
        res.ExpectedTrancheLoss = reader.GetDouble(reader.GetOrdinal("Expected_Tranche_Loss"))
        res.BaseCorrelation = reader.GetDouble(reader.GetOrdinal("Base_Correlation"))
        res.LossOnSingleNameDefault = reader.GetDouble(reader.GetOrdinal("Loss_on_Single_Name_Default"))
        res.RiskCapitalAllocation = reader.GetDouble(reader.GetOrdinal("Risk_Capital_Allocation"))
        res.MarginFundingAllocation = reader.GetDouble(reader.GetOrdinal("Margin_Funding_Allocation"))
        res.DataSource = reader.GetString(reader.GetOrdinal("DataSource"))
        Return res
    End Function
