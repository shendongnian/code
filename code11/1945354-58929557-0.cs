    public class EmployeeDTO
    {
        public string emp_id { get; set; }
        public string fullname { get; set; }
        public List<EmployeeDTO> EmployeeDTOMap(List<employeeinfo> entities)
        {
            return entities.Select(o => new EmployeeDTO
            {
                emp_id = o.emp_id,
                fullname = string.Format("{0} {1}", o.firstname, o.lastname)
            }).ToList();
        }
    }
