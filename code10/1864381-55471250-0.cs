    interface ITerminator
    {
        void Exit();
    }
    class RealTerminator
    {
        void Exit()=>Environment.Exit();
    }
    public class MyErrorChecker
    {
        ITerminator _terminator;
        public class MyErrorChecker(ITerminator terminator)
        {
            _terminator=terminator;
        }
        public void ErrorEncounter()
        {
            //Global Error Counter
            gblErrorCount++;
         
            //Process tremination
            _terminator.Exit();
        }
    }
