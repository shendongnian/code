    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class Welcome
    {
        [JsonProperty("Employees")]
        public Employee[] Employees { get; set; }
    }
    public partial class Employee
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("jobTitleName")]
        public string JobTitleName { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
  
     var JSONObj= JsonConvert.DeserializeObject<Welcome>(json); //convert you json in to class object
    
       var EmpArray=JSONObj["Employees"]; // will give you employee array
 
