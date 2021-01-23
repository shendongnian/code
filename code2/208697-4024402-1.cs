        public void DoSomething(IService service)
        {
            if (service is Service1)
            {
                //DO something
            }
            else if (service is Service2)
            {
                //DO something else
            }           
        }
