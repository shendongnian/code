	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace FEV.TOPexpert.Common.Extensions
	{
		public static class IEnumerableOfStringExtension
		{
			/// <summary>
			/// Finds the most common left string in a sequence of strings.
			/// </summary>
			/// <param name="source">The sequence to search in.</param>
			/// <returns>The most common left string in the sequence.</returns>
			public static string MostCommonLeftString(this IEnumerable<string> source)
			{
				return source.MostCommonLeftString(StringComparison.InvariantCulture);
			}
			/// <summary>
			/// Finds the most common left string in a sequence of strings.
			/// </summary>
			/// <param name="source">The sequence to search in.</param>
			/// <param name="comparisonType">Type of the comparison.</param>
			/// <returns>The most common left string in the sequence.</returns>
			public static string MostCommonLeftString(this IEnumerable<string> source, StringComparison comparisonType)
			{
				if (source == null)
					throw new ArgumentNullException("source");
				string mcs = String.Empty;
				using (var e = source.GetEnumerator())
				{
					if (!e.MoveNext())
						return mcs;
					mcs = e.Current;
					while (e.MoveNext())
						mcs = mcs.MostCommonLeftString(e.Current, comparisonType);
				}
				return mcs;
			}
			/// <summary>
			/// Returns a sequence with the most common left strings from a sequence of strings.
			/// </summary>
			/// <param name="source">A sequence of string to search through.</param>
			/// <returns>A sequence of the most common left strings ordered in descending order.</returns>
			public static IEnumerable<string> MostCommonLeftStrings(this IEnumerable<string> source)
			{
				return MostCommonLeftStrings(source, StringComparison.InvariantCulture);
			}
			/// <summary>
			/// Returns a sequence with the most common left strings from a sequence of strings.
			/// </summary>
			/// <param name="source">A sequence of string to search through.</param>
			/// <param name="comparisonType">Type of comparison.</param>
			/// <returns>A sequence of the most common left strings ordered in descending order.</returns>
			public static IEnumerable<string> MostCommonLeftStrings(this IEnumerable<string> source, StringComparison comparisonType)
			{
				if (source == null)
					throw new ArgumentNullException("source");
				var listOfMcs = new List<string>();
				using (var e = source.GetEnumerator())
				{
					while (e.MoveNext())
					{
						if (e.Current == null)
							continue;
						string removeFromList = String.Empty;
						string addToList = String.Empty;
						foreach (var element in listOfMcs)
						{
							addToList = e.Current.MostCommonLeftString(element, comparisonType);
							if (addToList.Length > 0)
							{
								removeFromList = element;
								break;
							}
						}
						if (removeFromList.Length <= 0)
						{
							listOfMcs.Add(e.Current);
							continue;
						}
						if (addToList != removeFromList)
						{
							listOfMcs.Remove(removeFromList);
							listOfMcs.Add(addToList);
						}
					}
				}
				return listOfMcs.OrderByDescending(item => item.Length);
			}
			/// <summary>
			/// Returns a string that both strings have in common started from the left.
			/// </summary>
			/// <param name="first">The first string.</param>
			/// <param name="second">The second string.</param>
			/// <returns>Returns a string that both strings have in common started from the left.</returns>
			public static string MostCommonLeftString(this string first, string second)
			{
				return first.MostCommonLeftString(second, StringComparison.InvariantCulture);
			}
			/// <summary>
			/// Returns a string that both strings have in common started from the left.
			/// </summary>
			/// <param name="first">The first string.</param>
			/// <param name="second">The second string.</param>
			/// <param name="comparisonType">Type of comparison.</param>
			/// <returns>Returns a string that both strings have in common started from the left.</returns>
			public static string MostCommonLeftString(this string first, string second, StringComparison comparisonType)
			{
				if (first == null
					|| second == null)
					return null;
				int length = Math.Min(first.Length, second.Length);
				first = first.Substring(0, length);
				second = second.Substring(0, length);
				while (!first.Equals(second, comparisonType))
				{
					first = first.Substring(0, first.Length - 1);
					second = second.Substring(0, second.Length - 1);
				}
				return first;
			}
			private static bool MatchesWithList(string match, IList<string> elements, StringComparison comparisonType)
			{
				string removeFromList = String.Empty;
				string addToList = String.Empty;
				foreach (var element in elements)
				{
					addToList = match.MostCommonLeftString(element, comparisonType);
					if (addToList.Length > 0)
					{
						removeFromList = element;
					}
				}
				if (removeFromList.Length > 0)
				{
					if (addToList != removeFromList)
					{
						elements.Remove(removeFromList);
						elements.Add(addToList);
					}
					return true;
				}
				return false;
			}
		}
	}
