        public class ProjectValidator : AbstractValidator<ProjectViewModel>
        {
            public ProjectValidator()
            {
                RuleFor(h => h.Application).NotNull().WithName("Application");
                RuleFor(h => h.FundingType).NotNull().WithName("Funding Type");
                RuleFor(h => h.Description).NotEmpty().WithName("Description");
                RuleFor(h => h.Name).NotEmpty().WithName("Project Name");
            }
        }
        [Validator(typeof(ProjectValidator))]
        public class ProjectViewModel
        {
            public string Application { get; set; }
            public string FundingType { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
        }
