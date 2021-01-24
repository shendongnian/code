    public class PatientBilling
    {
        private readonly IBillingHandlerByInsuranceSelector _billingHandlerSelector;
        private readonly IBillingHandler _directPatientBilling;
        public PatientBilling(
            IBillingHandlerByInsuranceSelector billingHandlerSelector, 
            IBillingHandler directPatientBilling)
        {
            _billingHandlerSelector = billingHandlerSelector;
            _directPatientBilling = directPatientBilling;
        }
        public void BillPatientForTreatment(Patient patient, Treatment treatment)
        {
            var billingHandler = _billingHandlerSelector.GetBillingHandler(patient.Insurance);
            var result = billingHandler.BillSomeone(patient, treatment);
            if (!result.Accepted)
            {
                _directPatientBilling.BillSomeone(patient, treatment);
            }
        }
    }
