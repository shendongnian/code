    public class OnlineDiscountStateMachine : StateMachine<OnlineDiscountState, OnlineDiscountCommand>
    {
        public OnlineDiscountStateMachine() : base(OnlineDiscountState.Disconnected)
        {
            AddTransition(OnlineDiscountState.Disconnected, OnlineDiscountCommand.Connect, OnlineDiscountState.Connected);
            AddTransition(OnlineDiscountState.Disconnected, OnlineDiscountCommand.Connect, OnlineDiscountState.Error_AuthenticationError);
            AddTransition(OnlineDiscountState.Connected, OnlineDiscountCommand.Submit, OnlineDiscountState.WaitingForResponse);
            AddTransition(OnlineDiscountState.WaitingForResponse, OnlineDiscountCommand.DataReceived, OnlineDiscountState.Disconnected);
        }
    }
