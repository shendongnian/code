    public class IsValidCupomRule : DiscountRule {
        private readonly ISalesRepository _salesRepository;
        public IsValidCupomRule(RuleHandlingDelegate<ApplyDiscountContext> next, ISalesRepository salesRepository)
            : base(next) {
            _salesRepository = salesRepository;
        }
        public override async Task Invoke(ApplyDiscountContext context) {
            if (cupomAvailable(context)) {
                // Gets 7% of discount;
                var myDiscount = context.Context.Items.Sum(i => i.Price * 0.07M);
                await next.Invoke(context);
                // Only apply discount if the discount applied by the other rules are smaller than this
                if (myDiscount > context.DiscountApplied) {
                    context.DiscountApplied = myDiscount;
                    context.DiscountTypeApplied = "Cupom";
                }
            } else
                await next(context);
        }
        private bool cupomAvailable(ApplyDiscountContext context) {
            return !string.IsNullOrWhiteSpace(context.Context.CupomCode)
                && context.Context.Items?.Count > 1
                && _salesRepository.IsCupomAvaliable(context.Context.CupomCode);
        }
    }
