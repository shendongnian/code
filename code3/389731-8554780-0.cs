    using System.Threading;
    const int CUTOFF_DEPTH = 6;//Maximum plys for alpha-beta
    AIState state;
    void AIAct()
    {
        state = new AIState( this.GameBoard.GetState() );
	ThreadPool.QueueUserWorkItem(RunMinimax, state);
        
        //assume that timerTick is a Timer (Windows Forms Timer) that ticks every 100 ms
        timerTick.Enabled = true;
    }
    
    void timerTick_Tick(object sender, EventArgs e)
    {
        if (state.IsComplete)
        {
            ExecuteAction(state.Result);
            timerTick.Enabled = false;
            //whatever else you need to do
        }
    }
    private static void RunMinimax(object args)
    {
        AIState state = args as AIState;
        if (state == null)
        {
            //error handling of some sort
            Thread.CurrentThread.Abort();
        }
        //run your minimax function up to max depth of CUTOFF_DEPTH
        state.Result = Minimax( /* */ );
        state.IsComplete = true;
    }
    private class AIState
    {
        public AIState(GameBoard board)
        {
            this.Board = board;
        }
        public readonly GameBoard Board;
        public AIAction Result;
        public volatile bool IsComplete;
    }
