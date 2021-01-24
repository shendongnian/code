using System;
using System.Net;
using Newtonsoft.Json;
					
public class Program
{
	public static void Main()
	{
		string json = new WebClient().DownloadString("** YOUR URL **");
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
        Console.WriteLine("Lat:             " + weatherData.Lat);
        Console.WriteLine("Lon:             " + weatherData.Lon);
		Console.WriteLine("Alt_M:           " + weatherData.Alt_M);
		Console.WriteLine("Alt_FT:          " + weatherData.Alt_FT);
		Console.WriteLine("WX_Desc:         " + weatherData.WX_Desc);
		Console.WriteLine("WX_Code:         " + weatherData.WX_Code);
		Console.WriteLine("WX_Icon:         " + weatherData.WX_Icon);
		Console.WriteLine("Temp_C:          " + weatherData.Temp_C);
        Console.WriteLine("Temp_F:          " + weatherData.Temp_F);
        Console.WriteLine("Feelslike_C:     " + weatherData.Feelslike_C);
        Console.WriteLine("Feelslike_F:     " + weatherData.Feelslike_F);
        Console.WriteLine("Humid_PCT:       " + weatherData.Humid_PCT);
        Console.WriteLine("Windspd_MPH:     " + weatherData.Windspd_MPH);
		Console.WriteLine("Windspd_KMH:     " + weatherData.Windspd_KMH);
        Console.WriteLine("Windspd_KTS:     " + weatherData.Windspd_KTS);
        Console.WriteLine("Windspd_MS:      " + weatherData.Windspd_MS);
        Console.WriteLine("Winddir_DEG:     " + weatherData.Winddir_DEG);
        Console.WriteLine("Winddir_Compass: " + weatherData.Winddir_Compass);
        Console.WriteLine("Cloudtotal_PCT:  " + weatherData.Cloudtotal_PCT);
        Console.WriteLine("Vis_KM:          " + weatherData.Vis_KM);
        Console.WriteLine("Vis_MI:          " + weatherData.Vis_MI);
		Console.WriteLine("Vis_Desc:        " + weatherData.Vis_Desc);
        Console.WriteLine("\n");
	}
}
public class WeatherData
{
    public string Lat { get; set; }
    public string Lon { get; set; }
	public string Alt_M { get; set; }
	public string Alt_FT { get; set; }
	public string WX_Desc { get; set; }
	public string WX_Code { get; set; }
	public string WX_Icon { get; set; }
	public string Temp_C { get; set; }
    public string Temp_F { get; set; }
    public string Feelslike_C { get; set; }
    public string Feelslike_F { get; set; }
    public string Humid_PCT { get; set; }
    public string Windspd_MPH { get; set; }
	public string Windspd_KMH { get; set; }
    public string Windspd_KTS { get; set; }
    public string Windspd_MS { get; set; }
    public string Winddir_DEG { get; set; }
    public string Winddir_Compass { get; set; }
    public string Cloudtotal_PCT { get; set; }
    public string Vis_KM { get; set; }
    public string Vis_MI { get; set; }
	public string Vis_Desc { get; set; }
    // OTHER PROPERTIES HERE ...
}
