public static bool IsNullOrWithSpaceWithLog(string x){
  log.Info("something")
  return string.IsNullOrWithSpace(x);
}
CreateMap<TestClass, TestClass>()
    .ForMember(d => d.Property1, c => c.Condition((s, d) => IsNullOrWithSpaceWithLog(d.Property1));
