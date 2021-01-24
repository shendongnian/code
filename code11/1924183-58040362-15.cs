    catch (MovedPermanentlyException exception)
    {
      var handler = Activator.CreateInstance(handlerType) as ISaberpsicologiaExceptionHandler;
      MethodInfo reflectedMethod = handlerType.GetMethod("Result");
      MethodInfo genericMethod = reflectedMethod.MakeGenericMethod(exception.GetType());
      object[] args = {exception};
      genericMethod.Invoke(this, args);
    }
