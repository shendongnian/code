        odsm = new OnlineDiscountStateMachine();
        public void Connect()
        {
            var result = odsm.TryGetNext(OnlineDiscountCommand.Connect);
            if (!result.IsValid)
                throw new Exception("invalid state");
            else if(result.NewState == OnlineDiscountState.Error_AuthenticationError)
                throw new Exception("invalid user/pass");
        }
