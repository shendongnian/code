    private int _grade
    public int Grade {
        get { return _grade;}
        set {
            if (value < lowerLimit) {
                throw new ArgumentOutOfRangeException("value",
                    string.Format("Grade must be higher than or equal to {0}.", lowerLimit)
                );
            }
            _grade = value; // will not happen if the exception was thrown
        }
    }
