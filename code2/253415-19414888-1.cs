		public string DumpClay(dynamic clay, int indent = 0, bool appendLine = true)
		{
			var indentStr = new string('\t', indent);
			if (!(clay is Clay))
			{
				return indentStr + clay.ToString()
					+ (appendLine ? ((indent == 0) ? ";" : ",") + Environment.NewLine : "");
			}
			var sb = new StringBuilder();
			if (IsArray(clay))
			{
				sb.Append(indentStr).AppendLine("[");
				foreach (var item in clay)
				{
					sb.AppendLine(DumpClay(item, indent + 2));
				}
				sb.Append(indentStr).Append("]");
			}
			PropBehavior behaviour;
			if (IsProp(clay, out behaviour))
			{
				if (sb.Length > 0)
				{
					sb.AppendLine();
				}
				sb.Append(indentStr).AppendLine("{");
				foreach (var pair in GetProps(behaviour))
				{
					sb.Append(DumpClay(pair.Key, indent + 1, appendLine: false)).AppendLine(":")
						.AppendLine(DumpClay(pair.Value, indent + 2));
				}
				sb.Append(indentStr).Append("}");
			}
			if (appendLine)
			{
				sb.AppendLine((indent == 0) ? ";" : ",");
			}
			return sb.ToString();
		}
		private static bool IsArray(Clay clay)
		{
			var behaviours = GetBehaviorCollection(clay);
			var arrayBehaviour = behaviours.FirstOrDefault(clayBehavior => clayBehavior is ArrayBehavior);
			return (arrayBehaviour != null);
		}
		private static bool IsProp(Clay clay, out PropBehavior propBehavior)
		{
			var behaviours = GetBehaviorCollection(clay);
			propBehavior = (PropBehavior)behaviours.FirstOrDefault(clayBehavior => clayBehavior is PropBehavior);
			return (propBehavior != null);
		}
		private static IEnumerable<IClayBehavior> GetBehaviorCollection(Clay clay)
		{
    // ReSharper disable PossibleNullReferenceException
			return (ClayBehaviorCollection)typeof(Clay)
				.GetField("_behavior", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(clay);
    // ReSharper restore PossibleNullReferenceException
		}
		private static IEnumerable<KeyValuePair<object, object>> GetProps(PropBehavior propBehavior)
		{
    // ReSharper disable PossibleNullReferenceException
			return (Dictionary<object, object>)typeof(PropBehavior)
				.GetField("_props", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(propBehavior);
    // ReSharper restore PossibleNullReferenceException
		}
