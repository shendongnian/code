       public class IsTests
    {
        [Fact]
        public void IsTheBarMethodWithOneIntParameterFromInterface()
        {
            var method = typeof(IFoo).GetMethod(nameof(IFoo.Bar), new []{typeof(int)});
            method.Is<IFoo>(m => m.Bar(default(int)))
                .Should().BeTrue("This is the method I intended");
            method.Is<IFoo>(m => m.Bar(default(int)), strict: true)
                .Should().BeTrue("This is the method I intended");
        }
        [Fact]
        public void IsTheBarMethodWithOneIntParameterFromImplementingClass()
        {
            var method = typeof(Foo).GetMethod(nameof(Foo.Bar), new[] { typeof(int) });
            method.Is<IFoo>(m => m.Bar(default(int)))
                .Should().BeTrue("This is the method I intended");
            method.Is<IFoo>(m => m.Bar(default(int)), strict: true)
                .Should().BeFalse("In strict mode the reference of the interface can not be used to identify the concrete implementation.");
        }
        [Fact]
        public void IsNotTheBarMethodWithOneStringParameter()
        {
            var method = typeof(Foo).GetMethod(nameof(Foo.Bar), new[] { typeof(int) });
            method.Is<IFoo>(m => m.Bar(default(string)))
                .Should().BeFalse("This is not the method I intended");
            method.Is<IFoo>(m => m.Bar(default(string)), strict:true)
                .Should().BeFalse("This is not the method I intended");
        }
        [Fact]
        public void IsTheBarMethodWithAnInterfaceParameter()
        {
            var method = typeof(Foo).GetMethod(nameof(Foo.Bar), new[] { typeof(IFoo) });
            method.Is<Foo>(m => m.Bar(default(IFoo)))
                .Should().BeTrue("This is the method I intended");
            method.Is<Foo>(m => m.Bar(default(IFoo)), strict:true)
                .Should().BeTrue("This is the method I intended");
        }
        [Fact]
        public void IsTheOnlyMethodWithTwoParamters()
        {
            var method = typeof(Foo).GetMethod(nameof(Foo.Bar), new[] { typeof(int), typeof(int) });
            method.Is<Foo>(m => m.Bar(default, default))
                .Should().BeTrue("This is the method I intended");
            method.Is<Foo>(m => m.Bar(default, default), strict: true)
                .Should().BeTrue("This is the method I intended");
            method.Is<IFoo>(m => m.Bar(default, default))
                .Should().BeTrue("This is the method I intended");
            method.Is<IFoo>(m => m.Bar(default, default), strict: true)
                .Should().BeFalse("In strict mode a interface reference can not be used on a concrete method");
        }
        [Fact]
        public void IsTheMethodThatHasUnreachableOverloads()
        {
            //the next line would give a AmbiguousMatchException at run time 
            //var method = typeof(Quux).GetMethod(nameof(Qux<int>.Bar), new[] {typeof(int), typeof(int) });
            //so, I used some helper function I found on 
            //http://blog.functionalfun.net/2009/10/getting-methodinfo-of-generic-method.html
            var method = MethodInfoExtension.GetMethodInfo(() => new Quux().Bar(1, 1));
            method.Is<Qux<int>>(m => m.Bar(default, default))
                .Should().BeTrue("This is the method I intended");
        }
        [Fact]
        public void IsTheMethodThatHasUnreachableOverloads_2()
        {
            var method = MethodInfoExtension.GetMethodInfo(() => new Quux().Bar(1, 1));
            //on could also specify a instance directly instead of default(type),
            method.Is<Qux<int>>(m => m.Bar(0, 0))
                .Should().BeTrue("This is the method I intended");
        }
        [Fact]
        public void IsTheMethodFromTheSpecificInterface()
        {
            var method = MethodInfoExtension.GetMethodInfo(() => (new Corge() as Grault).DoStuff());
            method.Is<Grault>(m => m.DoStuff(), strict: true)
                .Should().BeTrue("This is the method I intended");
            method.Is<Garply>(m => m.DoStuff(), strict: true)
                .Should().BeFalse("It is not the method I intended");
        }
    }
    public static class MethodInfoExtension
    {
        public static bool Is<T>(this MethodInfo self, Expression<Action<T>> selector, bool strict = false)
        {
            var body = (selector.Body as MethodCallExpression);
            if (body == null) return false;
            var methodName = body.Method.Name;
            if (self.Name != methodName) return false;
            if (strict && self.ReflectedType != body.Method.ReflectedType) return false;
            var parameterInfos = body.Method.GetParameters();
            var parameterCount = parameterInfos.Length;
            var parameters = self.GetParameters();
            if (parameters.Length != parameterCount) return false;
            return !parameters.Where((t, i) =>
                t.ParameterType != parameterInfos[i].ParameterType).Any();
        }
        public static MethodInfo GetMethodInfo(Expression<Action> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }
        #region GetMethodInfo
        //Helper methods found on //http://blog.functionalfun.net/2009/10/getting-methodinfo-of-generic-method.html
        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }
        public static MethodInfo GetMethodInfo<T, TResult>(Expression<Func<T, TResult>> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }
        public static MethodInfo GetMethodInfo(LambdaExpression expression)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;
            if (outermostExpression == null)
            {
                throw new ArgumentException("Invalid Expression. Expression should consist of a Method call only.");
            }
            return outermostExpression.Method;
        }
        #endregion
    }
    interface IFoo
    {
        void Bar();
        void Bar(string str);
        int Bar(int i);
        void Bar(int i1, int i2);
        void Bar(IFoo foo);
        IEnumerable<string> Bar1();
        void Bar1(string str);
        void Bar1(int i);
    }
    class Foo : IFoo
    {
        public void Bar() { }
        public void Bar(string str) { }
        public int Bar(int i) => default;
        public void Bar(int i1, int i2) { }
        public void Bar(IFoo foo) { }
        public IEnumerable<string> Bar1() => default;
        public void Bar1(string str) { }
        public void Bar1(int i) { }
    }
    class Qux<T> 
    {
        public void Bar(int x, T y) { }
        public void Bar(T x, int y) { }
        public void Bar(int x, int y) { }
    }
    class Quux : Qux<int>
    {
    }
    interface Grault
    {
        void DoStuff();
    }
    interface Garply
    {
        void DoStuff();
    }
    class Corge : Grault, Garply
    {
        void Grault.DoStuff() { }
        void Garply.DoStuff() { }
    }
