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
            static int Out;
    
            Establish context = () =>
            {
                int ignored;
                The<IFoo>().WhenToldTo(x => x.Foo(out ignored)).AssignOutAndRefParameters(42);
            };
    
            Because of = () => The<IFoo>().Foo(out Out);
    
            It should_assign_the_out_param = () => Out.ShouldEqual(42);
        }
    }
