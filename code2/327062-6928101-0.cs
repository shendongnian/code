    public Actions Actions{get; set;}
    
    public bool UseAction(Actions action)
            {
                bool mReturn = false;
    
                if (action == Actions.Action2)
                {
                    if ((this.Actions & Actions.Action2) == Actions.Action2)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~action;
                    }
                    else if ((this.Actions & Actions.Action3) == Actions.Action3)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~Actions.Action3;
                    }
                    else
                    {
                        mReturn = false;
                    }
                }
                else if (action == Actions.Action3)
                {
                    if ((this.Actions & Actions.Action3) == Actions.Action3)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~action;
                    }
                }
                else
                {
                    if ((this.Actions & Actions.Action1) == Actions.Action1)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~action;
                    }
                    else if ((this.Actions & Actions.Action3) == Actions.Action3)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~Actions.Action3;
                    }
                    else if ((this.Actions & Actions.Action2) == Actions.Action2)
                    {
                        mReturn = true;
                        this.Actions = this.Actions & ~Actions.Action2;
                    }
                }
    
                return mReturn;
            }
