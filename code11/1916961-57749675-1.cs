    .Where(x => x.Type == InvoiceType.BankDepositVoucher);
    if(!string.IsNullOrEmpty(search.VoucherNo))
        Voucher = Voucher.Where(x => x.VoucherNumber == search.VoucherNo);
    if(!string.IsNullOrEmpty(search.SlipNo))
        Voucher = Voucher.Where(x => x.BankDepositVoucher.SlipNo.Contains(search.SlipNo))
    // etc.
