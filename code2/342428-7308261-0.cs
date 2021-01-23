	var operators = new [] { "(", ")", "&&", "||", };
	Func<string, IEnumerable<string>> operatorSplit = t =>
	{
		Func<string, string, IEnumerable<string>> inner = null;
		inner = (p, x) =>
		{
			if (x.Length == 0)
			{
				return new [] { p, };
			}
			else
			{
				var op = operators.FirstOrDefault(o => x.StartsWith(o));
				if (op != null)
				{
					return (new [] { p, op }).Concat(inner("", x.Substring(op.Length)));
				}
				else
				{
					return inner(p + x.Substring(0, 1), x.Substring(1));
				}
			}
		};
		return inner("", t).Where(x => !String.IsNullOrEmpty(x));
	};
	
	var list = operatorSplit("0ò8F&|&&booBl||aBla").ToList();
