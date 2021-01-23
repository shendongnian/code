    private void RaisePostBackEvent(NameValueCollection postData)
    {
        if (this._registeredControlThatRequireRaiseEvent != null)
        {
            this.RaisePostBackEvent(this._registeredControlThatRequireRaiseEvent, null);
        }
        else
        {
            string str = postData["__EVENTTARGET"];
            bool flag = !string.IsNullOrEmpty(str);
            if (flag || (this.AutoPostBackControl != null))
            {
                Control control = null;
                if (flag)
                {
                    control = this.FindControl(str);
                }
                if ((control != null) && (control.PostBackEventHandler != null))
                {
                    string eventArgument = postData["__EVENTARGUMENT"];
                    this.RaisePostBackEvent(control.PostBackEventHandler, eventArgument);
                }
            }
            else
            {
                this.Validate();
            }
        }
    }
