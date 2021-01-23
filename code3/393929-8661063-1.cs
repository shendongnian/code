        List<string> strList = new List<string>();
        ThreadStart action = () => Method(strList);
        new Thread(action).Start();
        ...
        public void Method(List<string> list)
        {
            // Use list here
        }
