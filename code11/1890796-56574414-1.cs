    public static class AppStartupConfig
    {
        public static Dictionary<int,string> AttendanceStatus = new Dictionary<int,string>();
                
        public static void InitAppStuff(){
            //Bring basic data from database
            //fill the list looping data for e.g:
            if(AttendanceStatus.Count == 0){
               AttendanceStatus.Add(0,"Absent");
               AttendanceStatus.Add(1,"Present");
               AttendanceStatus.Add(2,"Unacceptable absent");
            }
        }
    }
