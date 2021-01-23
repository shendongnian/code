    private CheckState GetCheckStateFromAuthCode(int AuthCode)
    {
        switch (AuthCode)
        {
            case 0:
                // Unauthorized
                return CheckState.Unchecked;
            case 1:
                // Authorized, not enabled
                return CheckState.Indeterminate;
            case 2:
                // Authorized and enabled
                return CheckState.Checked;
            default:
                throw new ArgumentException("Unrecognized AuthCode value " + AuthCode.ToString());
        }
    }
