c#
builder.Register(ctx =>
  var version = ctx.Resolve<IContextInfoProvider>().GetVersion();
  if(version == 1)
  {
    return new SlowSender();
  }
  return new FastSender();
).As<ISender>();
