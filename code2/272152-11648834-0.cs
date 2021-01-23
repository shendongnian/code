    class parent
        {
            public virtual string saySomething(string s)
            {
                return s+":Parent";
            }
        }
        class man : parent
        {
            public override string saySomething(string s)
            {
                return s+":Man";
            }
        }
        class woman : parent
        {
            public override string saySomething(string s)
            {
                return s+":Woman";
            }
        }
        class child : parent
        {
            public override string saySomething(string s)
            {
                return s+":Child";
            }
        }
