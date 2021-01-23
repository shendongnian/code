           public void Method1()
        {
            CallContext.SetData("Key", 1);
            Method2();
        }
        public void Method2()
        {
            int value = (int)CallContext.GetData("Key");
        }
