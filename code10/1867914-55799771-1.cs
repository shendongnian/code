    Mapper.Initialize(cfg =>
	{
		cfg.CreateMap<Foo, Foo>()
			.IgnoreAllNonAttributedEntities()
			.ForAllOtherMembers(opts =>
			{
				opts.Condition((src, dest, srcMember) =>
				{
					var srcType = srcMember?.GetType();
					if (srcType is null)
					{
						return false;
					}
					return (srcType.IsClass && srcMember != null)
					|| (srcType.IsValueType
					&& !srcMember.Equals(Activator.CreateInstance(srcType)));
				});
			});
	});
