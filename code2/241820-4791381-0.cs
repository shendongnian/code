    var vouchers_temp = from v in db.Vouchers
                   select new
                   {
                       v.Amount,
                       v.Due_Date,
                       v.Invoice_Date,
                       v.PO_CC,
                       v.Vendor_No_,
                       v.Invoice_No_
                   };
    var vouchers = vouchers_temp.ToList().Select( new {
                       Amount,
                       Due_Date,
                       Invoice_Date,
                       PO_CC,
                       Vendor_No_,
                       Invoice_No_,
                       invoiceNumeric = MFUtil.StripNonNumeric(Invoice_No_)
    });
