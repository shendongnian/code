        public class CommandValidator : AbstractValidator<Command>
        {
            private ITenancyUserPermissions _permissions;
            public CommandValidator(ITenancyUserPermissions permissions)
            {
               _permissions = permissions;
                RuleFor(r => r).Must(HavePermissionToCreateTenancy).WithMessage("You do not have permission to create a tenancy.");
            }
            public bool HavePermissionToCreateTenancy(Command command)
            {
                 return _permissions.CanCreateTenancy(command.UserId);
            }
        }
