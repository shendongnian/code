    public SomeObject GetVersion(byte p)
    {
        switch ((SomeObject)p)
        {
            case Version.SomeType1:
                ...
                break;
            case Version.SomeType2:
                ...
                break;
            default:
                throw new UnexpectedQueryException(this.someOtherObject, errorCode);
        }
        return (SomeObject)p;
    }
