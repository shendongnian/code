    #region IPostBackDataHandler Members
        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            OnCheckedChanged(EventArgs.Empty);
        }
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            bool result = false;
            //check if a radio button in this button's group was selected
            string value = postCollection[GroupName];
            if ((value != null) && (value == Value)) //was the current radio selected?
            {
                if (!Checked) //select it if not already so
                {
                    Checked = true;
                    result = true;
                }
            }
            else //nothing or other radio in the group was selected
            {
                if (Checked) //initialize the correct select state
                {
                    Checked = false;
                }
            }
            return result;
        }
    #endregion
