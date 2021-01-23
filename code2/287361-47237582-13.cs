        odsm = new OnlineDiscountStateMachine();
        public void Connect()
        {
            var result = odsm.TryGetNext(OnlineDiscountCommand.Connect);
            //is result valid?
            if (!result.IsValid)
                //if this happens you need to add transitions to the state machine
                //in this case result.NewState is the same as before
                Console.WriteLine("cannot navigate from this state using OnlineDiscountCommand.Connect");
            //the transition was successfull
            //show messages for new states
            else if(result.NewState == OnlineDiscountState.Error_AuthenticationError)
                Console.WriteLine("invalid user/pass");
            else if(result.NewState == OnlineDiscountState.Connected)
                Console.WriteLine("Connected");
            else
                Console.WriteLine("not implemented transition result for " + result.NewState);
        }
