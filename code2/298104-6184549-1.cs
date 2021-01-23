		private static string MeToUpper(Match m)
		{
			return ((m.Value[0] != '\'') && (m.Value[0] != '\"'))
				? m.Value.ToUpper()
				: m.Value;
		}
		internal static string ToUpper(string codeSql)
		{
			Regex rgx = new Regex("(\'|\")?\\S+\\.\\S+");
			return rgx.Replace(codeSql, new MatchEvaluator(MeToUpper));
		}
