    var ldOnly = new Ledger_Only_DataType
    {
        Actuals_Ledger_ID = "1234567",
        Can_View_Budget_Date = true,
        Commitment_Ledger_Data = new[]
        {
            new Commitment_Ledger_Data__Public_Type
            {
                Commitment_Ledger_Reference = ledgerObject,
                Enable_Commitment_Ledger = true,
                Spend_Transaction_Data = st,
                Payroll_Transaction_Data = pt
            }
        }
    };
