        class A : IProtocolClient {
           public void connect( Type1 t1, Type2 t2, Type3 t3 ) {}
           void  IProtocolClient.connect(Type1 t1, Type2 t2, Type3 t3, Type4 t4){
         	throw new NotImplementedException();
           }     
     }
