    public class Foo
    {
       public Foo(ISession session){/*code*/}
       public Foo(ISessionFactory factory):this(factory.OpenSession()){}
    }
