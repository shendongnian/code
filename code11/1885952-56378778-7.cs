    public virtual string ParseDealerInventoryLink(string toParseLinkData)
	{
		string pattern = "{([^}]+)}";
		string text = toParseLinkData;
		RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled;
		if (!string.IsNullOrWhiteSpace(text))
		{
			dynamic dyn = new PropertyBag(this);
			Regex regex = new Regex(pattern, options);
			Dictionary<string, DealerInventoryLinkPatternParam> linkPatternMap = DealerInventoryFeedUrlParser.GetLinkPatternParamValueMap();
			text = regex.Replace(text, delegate(Match mat)
			{
				if (mat.Success && mat.Groups.Count > 0)
				{
					Group group = mat.Groups[mat.Groups.Count - 1];
					if (group.Success)
					{
						string value = group.Value;
						if (linkPatternMap.ContainsKey(value))
						{
							if (<>o__1.<>p__2 == null)
							{
								<>o__1.<>p__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(DealerInventoryFeedUrlParser)));
							}
							Func<CallSite, object, string> target = <>o__1.<>p__2.Target;
							CallSite<Func<CallSite, object, string>> <>p__ = <>o__1.<>p__2;
							if (<>o__1.<>p__1 == null)
							{
								<>o__1.<>p__1 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(DealerInventoryFeedUrlParser), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, Type, object, object> target2 = <>o__1.<>p__1.Target;
							CallSite<Func<CallSite, Type, object, object>> <>p__2 = <>o__1.<>p__1;
							Type typeFromHandle = typeof(Convert);
							if (<>o__1.<>p__0 == null)
							{
								<>o__1.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(DealerInventoryFeedUrlParser), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							return target(<>p__, target2(<>p__2, typeFromHandle, <>o__1.<>p__0.Target(<>o__1.<>p__0, dyn, linkPatternMap[value].ColumnName)));
						}
					}
				}
				return mat.Value;
			});
		}
		return text;
	}
