    interface IAct1
    {
        bool CanAct();
    }
    interface IAct2
    {
        bool CanAct();
    }
    class SometimesAct1SometimesAct2 : IAct, IAct1, IAct2
    {
        bool IAct1.CanAct()
        {
            return false;
        }
        bool IAct2.CanAct()
        {
            return true;
        }
        public bool CanAct()
        {
            Console.WriteLine("Called on IAct or SometimesAct1SometimesAct2");
            return false;
        }
    }
