c#
public class BranchEditViewModelValidator : AbstractValidator<BranchEditViewModel>
{
    public BranchEditViewModelValidator()
    {
        Include(new BranchViewModelValidator());
    }
}
