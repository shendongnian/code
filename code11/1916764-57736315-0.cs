c#
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json; // Install-Module Newtonsoft.JSON
namespace StackOverflow
{
    public class PowerReading
    {
        [JsonProperty("TERMINAL_NO")]
        public string TerminalNumber { get; set; }
        [JsonProperty("METER_NO")]
        public string MeterNumber { get; set; }
        public string RAMZE_RAYANEH_SHENASE_GHABZ { get; set; }
        public string PARVANDEH_ESHTERAK { get; set; }
        [JsonProperty("POWER_UTILITY")]
        public string PowerUtility { get; set; }
        public string CT_RATIO { get; set; }
        public string PT_RATIO { get; set; }
        [JsonProperty("NAME_")]
        public string Name { get; set; }
        public string Part { get; set; }
        [JsonProperty("CUSTOMER_ID")]
        public string CustomerId { get; set; }
        [JsonProperty("X_POS")]
        public string XPos { get; set; }
        [JsonProperty("Y_POS")]
        public string YPos { get; set; }
        public string DATE_NUM { get; set; }
        public string HOUR_NUM { get; set; }
        public string MONTH_ { get; set; }
        public string DAY_ { get; set; }
        public string YEAR_ { get; set; }
        public string DAY_WEEK { get; set; }
        public string DATE_HOUR { get; set; }
        public string ACTIVE_ENERGY_PLUS_TOTAL { get; set; }
        public string ACTIVE_ENERGY_PLUS_TARRIF1 { get; set; }
        public string ACTIVE_ENERGY_PLUS_TARRIF2 { get; set; }
        public string ACTIVE_ENERGY_PLUS_TARRIF3 { get; set; }
        public string ACTIVE_ENERGY_PLUS_TARRIF4 { get; set; }
        public string ACTIVE_ENERGY_MINUS_TOTAL { get; set; }
        public string ACTIVE_ENERGY_MINUS_TARRIF1 { get; set; }
        public string ACTIVE_ENERGY_MINUS_TARRIF2 { get; set; }
        public string ACTIVE_ENERGY_MINUS_TARRIF3 { get; set; }
        public string ACTIVE_ENERGY_MINUS_TARRIF4 { get; set; }
        public string REACTIVE_ENERGY_PLUS_TOTAL { get; set; }
        public string REACTIVE_ENERGY_PLUS_TARRIF1 { get; set; }
        public string REACTIVE_ENERGY_PLUS_TARRIF2 { get; set; }
        public string REACTIVE_ENERGY_PLUS_TARRIF3 { get; set; }
        public string REACTIVE_ENERGY_PLUS_TARRIF4 { get; set; }
        public string REACTIVE_ENERGY_MINUS_TOTAL { get; set; }
        public string REACTIVE_ENERGY_MINUS_TARRIF1 { get; set; }
        public string REACTIVE_ENERGY_MINUS_TARRIF2 { get; set; }
        public string REACTIVE_ENERGY_MINUS_TARRIF3 { get; set; }
        public string REACTIVE_ENERGY_MINUS_TARRIF4 { get; set; }
        public string VOLTAGE_PHASE_A { get; set; }
        public string VOLTAGE_PHASE_B { get; set; }
        public string VOLTAGE_PHASE_C { get; set; }
        public string CURRENT_PHASE_A { get; set; }
        public string CURRENT_PHASE_B { get; set; }
        public string CURRENT_PHASE_C { get; set; }
        public string POWER_ACTIV_AVG { get; set; }
        public string POWER_ACTIV_MIN { get; set; }
        public string POWER_ACTIV_MAX { get; set; }
        public string POWER_REACT_AVG { get; set; }
        public string POWER_REACT_MIN { get; set; }
        public string POWER_REACT_MAX { get; set; }
        public string POWER_FACTOR_PHASE_A { get; set; }
        public string POWER_FACTOR_PHASE_B { get; set; }
        public string POWER_FACTOR_PHASE_C { get; set; }
        public string READ_FLAG { get; set; }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            //First JSON pass: fix the JSON up enough to read in as an array of string arrays.
            var badJson = System.IO.File.ReadAllText("web_service.json");
            var arrayOfStringArrays = JsonConvert.DeserializeObject<string[][]>("[" + badJson + "]");
            //Use the first row as column headings (aka Object Property Names).
            var headings = arrayOfStringArrays.Take(1).FirstOrDefault();
            //Convert the remaining rows to a List of Dictionary<string,string> objects.
            var data = arrayOfStringArrays
                .Skip(1)
                .Select(row =>
                {
                    var colIndex = 0;
                    var dictionary = new System.Collections.Generic.Dictionary<string, string>();
                    row.ToList().ForEach(col => dictionary.Add(headings[colIndex++], col));
                    return dictionary;
                });
            //Serialize the List<Dictionary<string,string>> back to JSON.
            var goodJson = JsonConvert.SerializeObject(data);
            //Now we can deserialize the JSON to list of typed objects.
            var powerReadings = JsonConvert.DeserializeObject<IList<PowerReading>>(goodJson);
        }
    }
}
