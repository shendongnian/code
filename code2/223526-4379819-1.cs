    [OracleObjectMappingAttribute("AMOUNT")]
    public decimal AMOUNT {
        get {
            return this.m_AMOUNT;
        }
        set {
            this.AMOUNTIsNull = false;
            this.m_AMOUNT = value;
        }
    }
