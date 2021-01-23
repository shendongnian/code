    public Byte[] TheNumber
    {
        private set;
        get
        {
            return null;
        }
    }
    public void SetNumber([Array(new int[] { 8 })] Byte[] number)
    {
        this.TheNumber = number;
    }
