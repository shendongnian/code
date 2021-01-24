    public class WhyCoBillingHandler : IBillingHandler
    {
        private readonly IWhyCoService _whyCoService;
        public WhyCoBillingHandler(IWhyCoService whyCoService)
        {
            _whyCoService = whyCoService;
        }
        public BillSomeoneResult BillSomeone(Patient patient, Treatment treatment)
        {
            // populate this from the patient and treatment
            WhyCoEligibilityRequest eligibilityRequest = ...;
            var elibility = _whyCoService.CheckEligibility(eligibilityRequest);
            if(!elibility.IsEligible)
                return new BillSomeoneResult(false, elibility.Reason);
            // create the bill
            WhyCoBillSubmission bill = ...;
            _whyCoService.SubmitBill(bill);
            return new BillSomeoneResult(true);
        }
    }
    public interface IWhyCoService
    {
        WhyCoEligibilityResponse CheckEligibility(WhyCoEligibilityRequest request);
        void SubmitBill(WhyCoBillSubmission bill);
    }
