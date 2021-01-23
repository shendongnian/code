    using FakeItEasy;
    
    using Machine.Fakes;
    using Machine.Specifications;
    
    namespace MSpecMFakesOutParam
    {
      public interface IFoo
      {
        void Foo(out int foo);
      }
    
      public class When_using_FakeItEasy_with_out_params : WithFakes
      {
        static IFoo Foo;
        static int Out;
    
        Establish context = () =>
        {
          Foo = An<IFoo>();
    
          var ignored = A<int>.Ignored;
          A.CallTo(() => Foo.Foo(out ignored)).AssignsOutAndRefParameters(42);
        };
    
        Because of = () => Foo.Foo(out Out);
    
        It should_assign_the_out_param =
          () => Out.ShouldEqual(42);
      }
    }
