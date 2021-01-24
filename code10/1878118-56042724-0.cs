public ClassA : IEntity
public ClassB: IEntity
public ClassC: IEntity
public IEntity FindById<T>(int ID)
{
   Type elementType = typeof(T);
   
   if(elementType.Equals(typeof(ClassA))
   {
      return ClassA.FindById(ID);
   }
   
   if(elementType.Equals(typeof(ClassB))
   {
      return ClassB.FindById(ID);
   }
   
   if(elementType.Equals(typeof(ClassC))
   {
      return ClassC.FindById(ID);
   }
}
