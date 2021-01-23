    from ot in OldTransactions
    select new Transactions {
            DevCenter = ot.Transaction_Dev_Center,
            Action  =   ot.Transaction_Action,
            Status  =   ot.Transaction_Status,
            ModificationDate =  ot.Modified,
            ModifiedBy = ot.ModifiedBy,
            CreatedBy = ot.CreatedBy,
            TransactionDate = (System.DateTime)ot.Transaction_Date,
            Transaction_Asset = (System.Int32)(
                 from oa in OldAssets 
                 where oa.Asset_Serial_Number == ot.Asset_Serial_Number && 
                       ot.Asset_Tag == oa.Asset_Tag
                 select oa.ID).FirstOrDefault(),
            Transaction_User = (System.Int32)(
                 from u in OldUsers 
                 where ot.User_EID == u.User_EID
                 select u.ID).
                     FirstOrDefault()) }
