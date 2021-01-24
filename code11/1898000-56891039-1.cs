    namespace Dto
    {
        public class GetProjectManager
        {
            public string ProjectManagerId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public IList<GetProjectDto> GetProjects { get; set; }
        }
    
        public class GetProjectDto
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
            public DateTime PlannedStartDate { get; set; }
            public DateTime PlannedEndDate { get; set; }
            public DateTime? ActualStartDate { get; set; }
            public DateTime? ActualEndDate { get; set; }
            public string ProjectDescription { get; set; }
        }
    }
