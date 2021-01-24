    public interface IBillingHandler
    {
        BillSomeoneResult BillSomeone(Patient patient, Treatment treatment);
    }
    public interface IBillingHandlerByInsuranceSelector
    {
        IBillingHandler GetBillingHandler(InsuranceType insurance);
    }
