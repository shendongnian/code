			bool isPalindrome = true;
			string s = "300212003";
			for (int i = 0; i < (s.Length / 2); i++)
			{
				if (s[i] != s[s.Length - i - 1])
				{
					isPalindrome = false;
					break;
				}
			}
			Console.WriteLine(isPalindrome);
