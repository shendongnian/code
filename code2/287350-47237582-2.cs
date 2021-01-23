    public class OnlineDiscountStateMachine : StateMachine<OnlineDiscountState, OnlineDiscountCommand>
    {
        public OnlineDiscountStateMachine() : base(OnlineDiscountState.Disconnected)
        {
            AddTransition(OnlineDiscountState.Disconnected, OnlineDiscountCommand.Connect, OnlineDiscountState.Connected);
            var result = this.TryGetNext(OnlineDiscountCommand.EnterDiscountCode);
        }
        public void Connect()
        {
            var result = TryGetNext(OnlineDiscountCommand.Connect);
            if (!result.IsValid)
                throw new Exception("invalid state");
            else if(result.NewState == OnlineDiscountState.Error_AuthenticationError)
                throw new Exception("invalid user/pass");
        }
    }
