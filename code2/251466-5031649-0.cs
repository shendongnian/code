    class Program
    {
        static void Main(string[] args)
        {
            var hm = new HurtMe();
            var dhm = new DontHurtMe();
            DoBadThings(hm);
            
            DoBadThings(dhm);
        }
        static void DoBadThings(IBusinessObject ibo) { }
    }
    interface IBusinessObject { }
    class DontHurtMe : IBusinessObject { }
    class HurtMe : IBusinessObject { }
