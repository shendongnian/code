`
RegisterService(Type MyQueryType)
{
  Service.AddQuery(T =>
  {
    var service = new ServiceFactory.New();
    var method = service.GetType().GetMethod("AddQueryType").MakeGenericMethod(new Type[] { MyQueryType });
    var result = /*cast to AddQueryType return type*/method.Invoke(service, null);
    return result.Register(T).Create();
  });
}
`
