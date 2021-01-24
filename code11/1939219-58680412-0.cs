    public class Results
    {
        [JsonProperty("Result")]
        public List<Employee> Result { get; set; }
        [JsonProperty("successFlg")]
        public long SuccessFlag { get; set; }
        [JsonProperty("errMsg")]
        public string ErrorMessage { get; set; }
    }
    public class Employee
    {
        [JsonProperty("EMP_CODE")]
        public long EmpCode { get; set; }
        [JsonProperty("EMP_NAME")]
        public string EmpName { get; set; }
        [JsonProperty("NAT_CODE")]
        public long NatCode { get; set; }
        [JsonProperty("DEPT_CODE")]
        public long DeptCode { get; set; }
        [JsonProperty("MOBILE_NO")]
        public long MobileNumber { get; set; }
    }
