    private int _interestRate = someDefault;
    public int InterestRate {
        get { return _interestRate; }
        set {
            if (value < 0 || value > 50)
                throw new SomeException(); // or just don't update _interestRate
            _interestRate = value;
        }
    }
