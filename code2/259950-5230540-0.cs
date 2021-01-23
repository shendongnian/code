     if ((this._wr is IIS7WorkerRequest) && (((this._context.NotificationContext.CurrentNotification == RequestNotification.AuthenticateRequest) && !this._context.NotificationContext.IsPostNotification) || (this._context.NotificationContext.CurrentNotification < RequestNotification.AuthenticateRequest)))
            {
                throw new InvalidOperationException(SR.GetString("Invalid_before_authentication"));
            }
            IntPtr userToken = this._wr.GetUserToken();
            if (userToken != IntPtr.Zero)
            {
                string serverVariable = this._wr.GetServerVariable("LOGON_USER");
                string str2 = this._wr.GetServerVariable("AUTH_TYPE");
                bool isAuthenticated = !string.IsNullOrEmpty(serverVariable) || (!string.IsNullOrEmpty(str2) && !StringUtil.EqualsIgnoreCase(str2, "basic"));
                this._logonUserIdentity = CreateWindowsIdentityWithAssert(userToken, (str2 == null) ? "" : str2, WindowsAccountType.Normal, isAuthenticated);
            }
