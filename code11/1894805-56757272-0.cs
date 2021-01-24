    public class SharedContainer : IDisposible
    {
        public someclassTypeA Var1 {get;}
        public someclassTypeB Var2 {get;}
        public someclassTypeC Var3 {get;}
    
        public SharedContainer()
        {
           Var1 = IdentifierClass.Object1.createObject();
           Var2 = IdentifierClass.Object2.createObject();
           Var3 = IdentifierClass.Object3.createObject();
        }
    
        public void Dispose()
        {
           Var1.Dispose();
           Var2.Dispose();
           Var3.Dispose();
        }
    }
