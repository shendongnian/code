    public class FirstOrderDiscountRule : DiscountRule {
        public FirstOrderDiscountRule(RuleHandlingDelegate<ApplyDiscountContext> next) : base(next) { }
        public override async Task Invoke(ApplyDiscountContext context) {
            if (shouldRun(context)) {
                // Gets 5% of discount;
                var myDiscount = context.Context.Items.Sum(i => i.Price * 0.05M);
                await next.Invoke(context);
                // Only apply discount if the discount applied by the other rules are smaller than this
                if (myDiscount > context.DiscountApplied) {
                    context.DiscountApplied = myDiscount;
                    context.DiscountTypeApplied = "First Order Discount";
                }
            } else
                await next.Invoke(context);
        }
        bool shouldRun(ApplyDiscountContext context) {
            return (bool)(context.Properties["IsFirstOrder"] ?? false);
        }
    }
    
