cs
public static class Ext
{
	public static string RemoveWhitespaces(this string input)
	{
		return new string(input.ToCharArray()
			.Where(c => !char.IsWhiteSpace(c))
			.ToArray());
	}
}
and usage
cs
string RESULT = "D_CA,     P_AMOUNT    ,D_SH,D_CU,D_TO,D_GO,D_LE,D_NU,D_CO,D_MU,D_PMU,D_DP,    P_COMMENT      ";
RESULT = RESULT.RemoveWhitespaces();
`Char.IsWhiteSpace` [method](https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev16.query%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Char.IsWhiteSpace)%3Bk(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.8#remarks) indicates all Unicode whitespace characters
