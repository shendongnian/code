csharp
using System;
using System.Text.RegularExpressions;
					
public class Program
{
	public static void Main()
	{
		var body = "show inventory<br><br>Name: \"My Device Name One\", DESCR: \"ASA 5506-XSSD\"<br>PID: ASA5506-SSD       , VID: N/A     , SN: MSA203301BV<br>WARD-99ST-FW01#Name:\"Chassis\", DESCR: \"ASA 5506-X with FirePOWER services, 8GE, AC, DES\"<br>PID: ASA5506 , VID: V06     , SN: JMX2042Y12V<br>Name: \"Storage Device 1\", DESCR: \"ASA5506-X SSD\"<br>PID: ASA5506-SSD       , VID: N/A     , SN:MSA203301BV<br>WARD-99ST-FW01#";
        var regex = new Regex("(SN: )(\\w+)");
        var indexStart = body.IndexOf("Chassis");
        var substringToParse = body.Substring(indexStart);
        var matchingResult = regex.Match(substringToParse);
        //SN: JMX2042Y12V
        var fullResult = matchingResult.Groups[0].Value;
		Console.WriteLine($"Full result: {fullResult}");
		
        //SN: (<- contains trailing space)
        var snGroup = matchingResult.Groups[1].Value;
		Console.WriteLine($"SN group result (with trailing space): {snGroup}");
		
        //JMX2042Y12V
        var valueGroup = matchingResult.Groups[2].Value;
		Console.WriteLine($"Value group result: {valueGroup}");
	}
}
