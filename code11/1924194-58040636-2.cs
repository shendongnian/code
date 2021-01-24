    public class ExceptionHandlerFilter : ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
            base.OnException(context);
            HandleResponseCodeByExceptionType(context);
        }
        private void HandleResponseCodeByExceptionType(ExceptionContext context) {
            var exception = context.Exception;
            if (!CanHandle(exception)) {
                return;
            }
            var mapping = new Dictionary<Type, Type>
            {
                { typeof(MovedPermanentlyException), typeof(MovedPermanentlyExceptionHandler) }
            };
            var exceptionType = exception.GetType();
            var handlerType = mapping[exceptionType];
            var handler = Activator.CreateInstance(handlerType);
            var expression = build(exceptionType).Compile();
            var result = expression.DynamicInvoke(exception, handler);
            context.Result = (IActionResult)result;
        }
        LambdaExpression build(Type exceptionType) {
            var type = typeof(ISaberpsicologiaExceptionHandler<>);
            var genericType = type.MakeGenericType(exceptionType); //ISaberpsicologiaExceptionHandler<MyException>
            var handle = genericType.GetMethod("Result", new[] { exceptionType });
            var func = typeof(Func<,,>);
            var delegateType = func.MakeGenericType(typeof(Exception), genericType, typeof(ActionResult));
            //Intension is to create the following expression:
            // Func<Exception,ISaberpsicologiaExceptionHandler<MyException>, ActionResult> function =
            // (exception, handler) => (new handler()).Result((MyException)exception);
            // exception =>
            var exception = Expression.Parameter(typeof(Exception), "exception");
            // handler =>
            var handler = Expression.Parameter(genericType, "handler");
            // (MyException)exception
            var cast = Expression.Convert(exception, exceptionType);
            // handler.Result((MyException)exception)
            var body = Expression.Call(handler, handle, cast);            
            //Func<TException, THandler<MyException>, ActionResult> (exception, handler) => 
            //  handler.Result((MyException)exception)
            var expression = Expression.Lambda(delegateType, body, exception, handler);
            return expression;
        }
    }
