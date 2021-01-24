    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    namespace SOTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json =
                    "{\"deviceId\":37,\"longMacAddress\":\"5884e40000000439\",\"shortMacAddress\":259,\"hoplist\":\"(259,3)\",\"associationTime\":\"2019-06-10 22:43:54\",\"lifeCheckInterval\":5,\"lastLiveCheck\":\"2019-06-11 07:11:37\",\"onlineStatus\":1,\"txPowerValue\":14,\"deviceType\":1,\"frequencyBand\":1,\"lastLivecheck\":\"2019-06-11 07:11:36\",\"disassociationState\":0,\"firmwareUpdateActivated\":0,\"firmwareUpdatePackagesSent\":0,\"firmwareUpdatePackagesUnsent\":0,\"firmwareUpdateInProgress\":0,\"deviceIdOem\":\"-1\",\"deviceNameOem\":\"-1\",\"deviceCompanyOem\":\"-1\",\"binaryInputCount\":0,\"binaryOutputCount\":0,\"analogInputCount\":0,\"characterStringCount\":1,\"location\":[{\"location\":\"UK\",\"locationWriteable\":1,\"changedAt\":\"2019-06-10 23:40:50\"}],\"description\":[{\"description\":\"DevKit\",\"descriptionWriteable\":1,\"changedAt\":\"2019-06-10 23:40:54\"}],\"binaryInput\":[],\"binaryOutput\":[],\"analogInput\":[],\"characterString\":[{\"characterString\":\"149+0.0+99+26.5+0\",\"characterStringWriteable\":1,\"changedAt\":\"2019-06-11 06:45:02\"}]}";
    
                var obj = JsonConvert.DeserializeObject<CharacterStrings>(json);
                Console.WriteLine($"Sensor Data: {obj.CharacterString.First().CharacterString}");
                Console.ReadKey();
            }
    
            public class CharacterStrings
            {
                public List<Characters> CharacterString { get; set; }
            }
    
            public class Characters
            {   public string CharacterString { get; set; }
                public long CharacterStringWriteable { get; set; }
                public DateTime ChangedAt { get; set; }
            }
        }
    }
