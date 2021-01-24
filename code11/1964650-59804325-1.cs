    public class UserLoginValidator : AbstractValidator<UserLogin>
        {
           public UserLoginValidator()
         {
                        
             RuleFor(user => user.Email).NotEmpty().WithMessage("You must enter an email address");
             RuleFor(user => user.Email).EmailAddress().WithMessage("You must provide a valid email address");
             RuleFor(user => user.Password).NotEmpty().WithMessage("You must enter a password");
             RuleFor(user => user.Password).MaximumLength(50).WithMessage("Password cannot be longer than 50 characters");
        }
     }
