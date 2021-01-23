        #region IDataErrorInfo Members
        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public override string Error
        {
            get
            {
                return this["UserCode"] + this["UserName"] + this["Password"] + this["ConfirmedPassword"] + this["EmailAddress"];
            }
        }
        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "UserCode":
                        if (!string.IsNullOrEmpty(UserCode) && UserCode.Length > 20)
                            return "User Code must be less than or equal to 20 characters";
                        break;
                    case "UserName":
                        if (!string.IsNullOrEmpty(UserCode) && UserCode.Length > 60)
                            return "User Name must be less than or equal to 60 characters";
                        break;
                    case "Password":
                        if (!string.IsNullOrEmpty(Password) && Password.Length > 60)
                            return "Password must be less than or equal to 60 characters";
                        break;
                    case "ConfirmedPassword":
                        if (Password != ConfirmedPassword)
                            return Properties.Resources.ErrorMessage_Password_ConfirmedPasswordDoesntMatch; 
                        break;
                    case "EmailAddress":
                        if (!string.IsNullOrEmpty(EmailAddress))
                        {
                            var r = new Regex(_emailRegex);
                            if (!r.IsMatch(EmailAddress))
                                return Properties.Resources.ErrorMessage_Email_InvalidEmailFormat;
                        }
                        break;
                }
                return string.Empty;
            }
        }
        #endregion
