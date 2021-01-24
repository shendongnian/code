            var exception = context.Exception;
            if (!CanHandle(exception)) return;
            var exceptionType = exception.GetType();
            if (exceptionType == typeof(MovedPermanantelyException)) {
                 var handler = new MovePermanentlyExceptionHandler();
                 handler.Result(exception);
            }
            else {
                // chain the rest of your handlers in else if statements with a default else
            }
        }
