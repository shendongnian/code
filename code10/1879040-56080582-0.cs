    var acordSubAccount = acordHolding.Investment.SubAccount.Single(
        sa => sa.ProductCode.Equals(productCode));
    if (acordSubAccount != null)
    {
        acordSubAccount.OLifEExtension.Add(ACORDUtil.CreateOLifEExtension(OlifeExtensions));
        return acordSubAccount;
    }
