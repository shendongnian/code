csharp
namespace One
{
	using System;
	public class Program
	{
		public static void Main()
		{
			var person = Two.PersonFactory.Create("123-45-6789");
			Console.WriteLine(person.SSN.Value);
			// Console.WriteLine(person.SSN.RawValue); // 'ISensitiveString' does not contain a definition for 'RawValue' and no accessible extension method 'RawValue' accepting a first argument of type 'ISensitiveString' could be found
		}
	}
}
namespace Two
{
	using System;
	using System.Security.Cryptography;
	
	public static class PersonFactory
	{
		public static IPerson Create(string SSN)
		{
			var result = new Person();
			result.SSN.RawValue = SSN;
			
			Console.WriteLine(result.SSN.RawValue);
			Console.WriteLine(result.SSN.Value);
			
			return result;
		}
	}
	public interface IPerson 
	{
		ISensitiveString SSN { get; }
	}
	internal class Person : IPerson
	{
		ISensitiveString IPerson.SSN => SSN;
		public SensitiveString SSN { get; set; } = new SensitiveString();
	}
	public interface ISensitiveString
	{
		string Value { get; }
	}
	
	internal class SensitiveString : ISensitiveString
	{
		public string Value
		{
			get
			{
				string result;
				using (var sha512 = SHA512.Create())
				{
	            	var bytes = System.Text.Encoding.UTF8.GetBytes(RawValue);
            		var hash = sha512.ComputeHash(bytes);
					var sb = new System.Text.StringBuilder(128);
        			foreach (var b in hash)
            			sb.Append(b.ToString("X2"));
					result = sb.ToString();
				}
				return result;
			}
		}
		
		public string RawValue { get; set; }
	}
}
Ouput
> 123-45-6789
> FBE47783B1D59D46DD437BDE9236A5404A8E8394F76E1C31D8421FD604D9BD1DF0C52DF5E5FD9C41879659D46C9A839266144E6C5FCAA678653290ED9EFFAEA7
> FBE47783B1D59D46DD437BDE9236A5404A8E8394F76E1C31D8421FD604D9BD1DF0C52DF5E5FD9C41879659D46C9A839266144E6C5FCAA678653290ED9EFFAEA7
