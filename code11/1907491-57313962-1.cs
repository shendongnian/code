public void copyAll(dynamic objFrom, dynamic objTo, Type t) {
    System.Reflection.PropertyInfo[] props = t.GetProperties();
    foreach (System.Reflection.PropertyInfo prop in props)
    {
         if (!prop.CanWrite) continue;
         dynamic value = prop.GetValue(objFrom);
         prop.SetValue(objTo, value);
    }
}
but now I can make my constructor like this:
class A{
   public A(B baseObj){
       Type t = typeof(B);
       CopyAll(user,this,t);
   }
}
That was annoying, but we are in business.
