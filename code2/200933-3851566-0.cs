		enum ParserState
		{
			Text,
			Bracketed,
			Quoted,
			EscapChar,
		}
		internal static IEnumerable<string> Split(string str, char sep)
		{
			int lastIdx = 0;
			char c;
			ParserState s;
			Stack<ParserState> state = new Stack<ParserState>();
			state.Push(ParserState.Text);
			for (int i = 0; i < str.Length; i++)
			{
				c = str[i];
				s = state.Peek();
				if (s == ParserState.EscapChar
					|| (s == ParserState.Bracketed && c == ']')
					|| (s == ParserState.Quoted && c == '"'))
				{
					state.Pop();
				}
				else if (c == '[')
					state.Push(ParserState.Bracketed);
				else if (c == '"')
					state.Push(ParserState.Quoted);
				else if (c == '\\')
					state.Push(ParserState.EscapChar);
				else if (s == ParserState.Text && c == sep)
				{
					yield return str.Substring(lastIdx, i - lastIdx);
					lastIdx = i + 1;
				}
			}
			yield return str.Substring(lastIdx);
		}
