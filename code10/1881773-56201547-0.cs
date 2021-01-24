    var type = request.GetType();
	var responseType = type.GetInterfaces() // [IRequest<MyResponse>]
        .Single(i => i.GetGenericTypeDefinition() == typeof(IRequest<>)) // IRequest<MyResponse>
        .GetGenericArguments() // [MyResponse]
        .Single(); // MyResponse
    var method = mediator.GetType().GetMethod("Send");
    var generic = method.MakeGenericMethod(responseType); // note that responseType is used here
    var response = generic.Invoke(mediator, new object[] { request });
