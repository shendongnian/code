    public class OnlineDiscountStateMachine : StateMachine<OnlineDiscountState, OnlineDiscountCommand>
    {
        public OnlineDiscountStateMachine() : base(OnlineDiscountState.Disconnected)
        {
            AddTransition(OnlineDiscountState.Disconnected, OnlineDiscountCommand.Connect, OnlineDiscountState.Connected);
            AddTransition(OnlineDiscountState.Disconnected, OnlineDiscountCommand.Connect, OnlineDiscountState.Error_AuthenticationError);
            AddTransition(OnlineDiscountState.Connected, OnlineDiscountCommand.Submit, OnlineDiscountState.WaitingForResponse);
            AddTransition(OnlineDiscountState.WaitingForResponse, OnlineDiscountCommand.DataReceived, OnlineDiscountState.Disconnected);
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
