    class Employee {
        public int[] DepartmentIds { get; set; }
        public List<Department> Departments {
            get {
                return YourStaticReference.DepartmentList
                    .Where(x => this.DepartmentIds.Contains(x.DepartmentId));
            }
        }
    }
