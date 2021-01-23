      public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
    {
        string str3;
        MembershipUser user;
        if (!SecUtility.ValidateParameter(ref password, true, true, false, 0x80))
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        string salt = this.GenerateSalt();
        string objValue = this.EncodePassword(password, (int) this._PasswordFormat, salt);
        if (objValue.Length > 0x80)
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        if (passwordAnswer != null)
        {
            passwordAnswer = passwordAnswer.Trim();
        }
        if (!string.IsNullOrEmpty(passwordAnswer))
        {
            if (passwordAnswer.Length > 0x80)
            {
                status = MembershipCreateStatus.InvalidAnswer;
                return null;
            }
            str3 = this.EncodePassword(passwordAnswer.ToLower(CultureInfo.InvariantCulture), (int) this._PasswordFormat, salt);
        }
        else
        {
            str3 = passwordAnswer;
        }
        if (!SecUtility.ValidateParameter(ref str3, this.RequiresQuestionAndAnswer, true, false, 0x80))
        {
            status = MembershipCreateStatus.InvalidAnswer;
            return null;
        }
        if (!SecUtility.ValidateParameter(ref username, true, true, true, 0x100))
        {
            status = MembershipCreateStatus.InvalidUserName;
            return null;
        }
        if (!SecUtility.ValidateParameter(ref email, this.RequiresUniqueEmail, this.RequiresUniqueEmail, false, 0x100))
        {
            status = MembershipCreateStatus.InvalidEmail;
            return null;
        }
        if (!SecUtility.ValidateParameter(ref passwordQuestion, this.RequiresQuestionAndAnswer, true, false, 0x100))
        {
            status = MembershipCreateStatus.InvalidQuestion;
            return null;
        }
        if ((providerUserKey != null) && !(providerUserKey is Guid))
        {
            status = MembershipCreateStatus.InvalidProviderUserKey;
            return null;
        }
        if (password.Length < this.MinRequiredPasswordLength)
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        int num = 0;
        for (int i = 0; i < password.Length; i++)
        {
            if (!char.IsLetterOrDigit(password, i))
            {
                num++;
            }
        }
        if (num < this.MinRequiredNonAlphanumericCharacters)
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        if ((this.PasswordStrengthRegularExpression.Length > 0) && !Regex.IsMatch(password, this.PasswordStrengthRegularExpression))
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        ValidatePasswordEventArgs e = new ValidatePasswordEventArgs(username, password, true);
        this.OnValidatingPassword(e);
        if (e.Cancel)
        {
            status = **MembershipCreateStatus.InvalidPassword**;
            return null;
        }
        try
        {
            SqlConnectionHolder connection = null;
            try
            {
                connection = SqlConnectionHelper.GetConnection(this._sqlConnectionString, true);
                this.CheckSchemaVersion(connection.Connection);
                DateTime time = this.RoundToSeconds(DateTime.UtcNow);
                SqlCommand command = new SqlCommand("dbo.aspnet_Membership_CreateUser", ....
                command.Parameters.Add(parameter);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    if (((exception.Number != 0xa43) && (exception.Number != 0xa29)) && (exception.Number != 0x9d0))
                    {
                        throw;
                    }
                    status = MembershipCreateStatus.DuplicateUserName;
                    return null;
                }
                int num3 = (parameter.Value != null) ? ((int) parameter.Value) : -1;
                if ((num3 < 0) || (num3 > 11))
                {
                    num3 = 11;
                }
                status = (MembershipCreateStatus) num3;
                if (num3 != 0)
                {
                    return null;
                }
                providerUserKey = new Guid(command.Parameters["@UserId"].Value.ToString());
                time = time.ToLocalTime();
                user = new MembershipUser(this.Name, username, providerUserKey, email, passwordQuestion, null, isApproved, false, time, time, time, time, new DateTime(0x6da, 1, 1));
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
        catch
        {
            throw;
        }
        return user;
    }
    internal static bool ValidateParameter(ref string param, bool checkForNull, bool checkIfEmpty, bool checkForCommas, int maxSize)
    {
        if (param == null)
        {
            return !checkForNull;
        }
        param = param.Trim();
        return (((!checkIfEmpty || (param.Length >= 1)) && ((maxSize <= 0) || (param.Length <= maxSize))) && (!checkForCommas || !param.Contains(",")));
    }
