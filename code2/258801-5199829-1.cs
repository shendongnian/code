        public class InstanceInformation
        {
            public string PatientID { get; set; } public string StudyID { get; set; } public string SeriesID { get; set; } public string InstanceID { get; set; }
            public override string ToString()
            {
                var r = string.Format("{0}/{1}/{2}/{3}", PatientID, StudyID, SeriesID, InstanceID);
                return r;
            }
        } 
    var listofstring = list.ConvertAll<string>(x => x.ToString()).ToList();
    var listofstringdistinct = listofstring.Distinct().ToList();
