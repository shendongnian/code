 c#
container.Register<IBannerGenerator, ObnoxiousBannerGenerator>();
container.Register<IPlainTalker, TimidSpeaker>();
container.Register<IBannerTalker, LoudMouth>();
container.RegisterConditional<IConsoleVoicer, ConsoleShouter>(
	c => c.Consumer.ImplementationType == typeof(LoudMouth));
container.RegisterConditional<IConsoleVoicer, ConsoleWhisperer>(
	c => c.Consumer.ImplementationType == typeof(TimidSpeaker));
