    public class ChildETLSchool : ETLBase
        {
            public ChildETLSchool(string sourceConnectionString, string destinationConnectionString) 
                : base(sourceConnectionString, destinationConnectionString)
            {
                //Change values of below lines only if you want to override the values
                //Select = @"Select THIS DataStatement";
                //CreateTemp = @"CREATE TABLE Statement";
                //Merge = @"Merge Table statement";
                //CleanUp = "DROP TABLE Statement";
                //DestinationTable = "##TempTable";
            }
           
        }
        public class ChildETLTeacher : ETLBase
        {
            public ChildETLTeacher(string sourceConnectionString, string destinationConnectionString) 
                : base(sourceConnectionString, destinationConnectionString)
            {
                //Change values of below lines only if you want to override the values
                //Select = @"Select THIS DataStatement";
                //CreateTemp = @"CREATE TABLE Statement";
                //Merge = @"Merge Table statement";
                //CleanUp = "DROP TABLE Statement";
                //DestinationTable = "##TempTable";
            }
        }
