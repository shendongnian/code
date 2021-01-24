    public class Employee
    {
        public Employee()
        {
            SelectedHobbies = new List<int>();
            ...
        }
        [Display(Name = "Please Select Hobbies")]
        public List<int> SelectedHobbies { get; set; }
        public MultiSelectList AvailableHobbies { get; set; }
        ...
    }
