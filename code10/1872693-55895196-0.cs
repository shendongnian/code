 public class BaseModelItemValidator : AbstractValidator<BaseModelItem>
    {
        public BaseModelItemValidator()
        {
            RuleFor(i => i.ItemId).GreaterThanOrEqualTo(0).WithMessage("Item id may not be negative.");
            RuleFor(i => i.Name).NotNull().NotEmpty().WithMessage("Item name cannot be empty.");
            RuleFor(i => i.ChildItems).Must(BeValidChildItemList);
        }
        private bool BeValidChildItemList(List<BaseModelItem> list)
        {
            if (list == null || list.Count == 0) return true;
            foreach (var child in list)
            {
                var validator = new BaseModelItemValidator();
                var validatorResults = validator.Validate(child);
                if (!validatorResults.IsValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
