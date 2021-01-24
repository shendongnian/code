    public class UserStatus
    {
        public string name { get; set; }
    }
    public class UserProfileDetail
    {
        public UserStatus userStatus { get; set; }
        public DateTime userStatusDate { get; set; }
        public DateTime lastAttestationDate { get; set; }
    }
    public class UserType
    {
        public string name { get; set; }
    }
    public class UserInformation
    {
            
        public int Id { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public string ssn { get; set; }
        public string ethnicity { get; set; }
        public List<string> languagesSpoken { get; set; }
        public string personalEmail { get; set; }
        public List<string> otherNames { get; set; }
        public UserType userType { get; set; }
        public string primaryuserState { get; set; }
        public List<string> otheruserState { get; set; }
        public string practiceSetting { get; set; }
        public string primaryEmail { get; set; }
    }
    public class GetUser
    {
        public override string ToString()
        {
            List<string> userData = new List<string>
            {
                userProfileDetail.userStatus.name,
                userProfileDetail.userStatusDate.ToString(),
                userProfileDetail.lastAttestationDate.ToString(),
                userInformation.Id.ToString(),
                userInformation.lastName,
                userInformation.suffix?? string.Empty ,
                userInformation.gender?? string.Empty ,
                userInformation.birthDate.ToString(),
                userInformation.ssn?? string.Empty ,
                userInformation.ethnicity?? string.Empty ,
                string.Join("|", userInformation.languagesSpoken?? new List<string>()),
                userInformation.personalEmail?? string.Empty ,
                string.Join("|", userInformation.otherNames?? new List<string>() ),
                userInformation.userType.name?? string.Empty ,
                userInformation.primaryuserState?? string.Empty ,
                string.Join("|", userInformation.otheruserState),
                userInformation.practiceSetting?? string.Empty ,
                userInformation.primaryEmail
            };
            return string.Join(",", userData);
        }
        public UserProfileDetail userProfileDetail { get; set; }
        public UserInformation userInformation { get; set; }
    }
    public class Data
    {
        public List<GetUser> getUsers { get; set; }
    }
    public class RootObject
    {
            public string GetHeader()
            {
                return "getUsers_userProfileDetail_userStatus_name,getUsers_userProfileDetail_userStatusDate,getUsers_userProfileDetail_lastAttestationDate,getUsers_userInformation_Id,getUsers_userInformation_lastName,getUsers_userInformation_suffix,getUsers_userInformation_gender,getUsers_userInformation_birthDate,getUsers_userInformation_ssn,getUsers_userInformation_ethnicity,getUsers_userInformation_languagesSpoken,getUsers_userInformation_personalEmail,getUsers_userInformation_otherNames,getUsers_userInformation_userType_name,getUsers_userInformation_primaryuserState,getUsers_userInformation_otheruserState,getUsers_userInformation_practiceSetting,getUsers_userInformation_primaryEmail";
            }
        public Data data { get; set; }
    }
**How to use the classes above**
    string json = File.ReadAllLines("locationOfJson");
    var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
    Console.WriteLine(rootObject.GetHeader()); // Prints Header
    foreach (var user in rootObject.data.getUsers)
    {
        Console.WriteLine(user.ToString()); // Print Each User.
    }
**Output**
Expired,4/4/2017 3:48:25 AM,2/1/2019 3:50:42 AM,13610875,************,,FEMALE,12/31/1969 7:01:00 PM,000000000,INVALID_REFERENCE_VALUE,,,,APN,CO,CO,INPATIENT_ONLY,*****@*****.com
  [1]: http://json2csharp.com/#
