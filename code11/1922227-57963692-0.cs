        List<Commitment_Ledger_Data__Public_Type> cls = new List<Commitment_Ledger_Data__Public_Type>();
        Commitment_Ledger_Data__Public_Type cl1 = new 
             Commitment_Ledger_Data__Public_Type
           {
               Commitment_Ledger_Reference = ledgerObject,
               Enable_Commitment_Ledger = true,
               Spend_Transaction_Data = st,
               Payroll_Transaction_Data = pt
           };
        cls.Add(cl1);
       ldOnly.Commitment_Ledger_Data = cls.ToArray();
