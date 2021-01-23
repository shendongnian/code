    if (newPassword.Length < this.MinRequiredPasswordLength)
    {
    	throw new ArgumentException(SR.GetString("Password_too_short", new object[] { "newPassword", this.MinRequiredPasswordLength.ToString(CultureInfo.InvariantCulture) }));
    }
    int num3 = 0;
    for (int i = 0; i < newPassword.Length; i++)
    {
    	if (!char.IsLetterOrDigit(newPassword, i))
    	{
    		num3++;
    	}
    }
    if (num3 < this.MinRequiredNonAlphanumericCharacters)
    {
    	throw new ArgumentException(SR.GetString("Password_need_more_non_alpha_numeric_chars", new object[] { "newPassword", this.MinRequiredNonAlphanumericCharacters.ToString(CultureInfo.InvariantCulture) }));
    }
    if ((this.PasswordStrengthRegularExpression.Length > 0) && !Regex.IsMatch(newPassword, this.PasswordStrengthRegularExpression))
    {
    	throw new ArgumentException(SR.GetString("Password_does_not_match_regular_expression", new object[] { "newPassword" }));
    }
