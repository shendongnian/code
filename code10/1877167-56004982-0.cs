csharp
public class AddEditChildViewModel
{
    public int ParentId { get; set; }
    public string ParentName { get; set; }
}
Then your validator doesn't have to jump through any hoops to validate data or display validation messages:
csharp
public class AddEditChildViewModelValidator : AbstractValidator<AddEditChildViewModel>
{
    public AddEditChildViewModelValidator()
    {
        RuleFor(m => m.ChildProperty)
            .Must(DoSomethingWithParentEntityData)
            .WithMessage("{0} {PropertyName} is required.", m => m.ParentName);
    }
    private bool DoSomethingWithParentEntityData(AddEditChildViewModel model, int childProperty)
    {
        // use model.ParentId for something
    }
}
