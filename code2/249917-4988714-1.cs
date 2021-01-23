    public override int GetHashCode()
    {
        unchecked
        {
            return ((BankCode != null ? BankCode.GetHashCode() : 0)*397) ^ (AccountNumber != null ? AccountNumber.GetHashCode() : 0);
        }
    }
