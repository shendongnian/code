            public override bool Equals(Object obj)
        {
            User testedUser = (User)obj;
            if (this._userName == testedUser.UserName &&
                this._userPassword == testedUser.UserPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
