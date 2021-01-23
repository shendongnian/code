    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace MethodStaticLocals
    {
        class ExpensiveObject 
        {
            public ExpensiveObject()
            {
                Console.WriteLine( "Creating Expensive object" );
            }
        };
    
        class MainClass
        {
            public static void Main( string[] args )
            {
                Expression<Action> call = () => Func( "hello" );
    
                Invoke( call );
                Invoke( call );
            }
    
            // caches handles for expresisons, as they are expensive to find.
            static Dictionary<Expression, RuntimeMethodHandle> handleCache = new Dictionary<Expression, RuntimeMethodHandle>();
            // static locals are managed per method handle
            static Dictionary<RuntimeMethodHandle, Dictionary<string, object>> staticLocals = new Dictionary<RuntimeMethodHandle, Dictionary<string, object>>();
            // redirects are individual for each expression tree
            static Dictionary<Expression, Delegate> redirects = new Dictionary<Expression, Delegate>();
    
            static void Invoke( Expression<Action> call )
            {
                if (call.Parameters != null && call.Parameters.Any())
                    throw new InvalidOperationException();
    
                if (call.Body.NodeType != ExpressionType.Call)
                    throw new InvalidOperationException();
    
                Delegate redirectedInvocation = SetupRedirectedInvocation( call );
    
                redirectedInvocation.DynamicInvoke();
               
            }
    
            private static Delegate SetupRedirectedInvocation( Expression<Action> call )
            {
                Delegate redirectedInvocation;
                if (!redirects.TryGetValue( call, out redirectedInvocation ))
                {
                    RuntimeMethodHandle caller = SetupCaller( call );
    
                    Console.WriteLine( "Creating redirect for {0}", caller.Value );
                    MethodCallExpression callExpression = (MethodCallExpression)call.Body;
    
                    // add staticLocals dictionary as argument
                    var arguments = callExpression.Arguments.ToList();
                    arguments.Add( Expression.Constant( staticLocals[caller] ) );
    
                    // todo: dynamically find redirect
                    var redirect = MethodOf( () => Func( default( string ), default( Dictionary<string, object> ) ) );
    
                    LambdaExpression redirectedExpression = Expression.Lambda( Expression.Call( callExpression.Object, redirect, arguments ), new ParameterExpression[0] );
    
                    redirectedInvocation = redirectedExpression.Compile();
                    redirects.Add( call, redirectedInvocation );
                }
                return redirectedInvocation;
            }
    
            private static RuntimeMethodHandle SetupCaller( Expression<Action> call )
            {
                RuntimeMethodHandle caller;
                if (!handleCache.TryGetValue( call, out caller ))
                {
                    caller = new StackFrame( 1 ).GetMethod().MethodHandle;
                    handleCache.Add( call, caller );
                    staticLocals.Add( caller, new Dictionary<string, object>() );
                }
                return caller;
            }
    
            public static MethodInfo MethodOf( Expression<Action> expression )
            {
                MethodCallExpression body = (MethodCallExpression)expression.Body;
                return body.Method;
            }
    
            [Obsolete( "do not call directly" )]
            public static void Func( string arg )
            {
            }
    
            private static void Func( string arg, Dictionary<string, object> staticLocals )
            {
                if (!staticLocals.ContainsKey( "expensive"))
                {
                    staticLocals.Add( "expensive", new ExpensiveObject() );
                }
    
                ExpensiveObject obj = (ExpensiveObject)staticLocals["expensive"];
                Console.WriteLine( "Func invoked: arg: {0}; expensive: {1}", arg, obj );
            }
        }
    }
