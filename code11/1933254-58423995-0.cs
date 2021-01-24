        public class EmployeeInfo {
            public List<String> TheList { get; } = new List<String>();
        }
        public void Test(){
            var employeeInfo = new EmployeeInfo();
            var hasValues = employeeInfo.TheList.Count( list => list.Any() );
            var noValues = employeeInfo.TheList.Count - hasValues;
        }
