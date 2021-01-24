public class Context<A, T>: IContext<A, T> where A : Answer<T>
{
   void SomeMethod()
   {
	A answer = Activator.CreateInstance<A>();
	answer.context = this;
   }
}
public class Answer<T>
{
   public IContext<Answer<T>, T> context { get; set; }
}
public interface IContext<out A, T> {}
