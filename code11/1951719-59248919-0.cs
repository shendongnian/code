C#
// Option #1
public class C<T>
{
   C(T p)
   {
       P = p
   }
   public T P { get; set; }
}
// option #2:
public class C<T> where T : new()
{
   C()
   {
       P = new T()
   }
   public T P { get; set; }
}
