    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(SupplierDataReport));
                SupplierDataReport report = (SupplierDataReport)serializer.Deserialize(reader);
            }
     
        }
        public class SupplierDataReport
        {
            public Header Header { get;set;}
            [XmlArray("Products")]
            [XmlArrayItem("ProductDetails")]
            public List<ProductDetails> ProductDetails { get; set; }
        }
        public class Header
        {
            public string Note { get;set;}
            public string UserName { get;set;}
            public string DateDrawn { get;set;}
            public string Group { get;set;}
            public string Branch { get;set;}
            public string Product { get;set;}
            public string Administrator { get;set;}
            public string Claims { get;set;}
            public string Owner { get;set;}
            public string Underwriter { get;set;}
            private DateTime _StartDate { get; set; }
            public string  StartDate {
                get { return _StartDate.ToString("dd MMM yyyy"); }
                set { _StartDate = DateTime.ParseExact(value, "dd MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);}
            }
            private DateTime _EndDate { get; set; }
            public string EndDate
            {
                get { return _EndDate.ToString("dd MMM yyyy"); }
                set { _EndDate = DateTime.ParseExact(value, "dd MMM yyyy", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public string DeclinedTransactions { get; set; }
            public string DraftMode { get; set; }
            public string DraftMessage { get; set; }
            public int NumberofRecords { get; set; }
        }
        public class ProductDetails
        {
            public Transaction Transaction { get; set; }
            public Client Client { get; set; }
            public Vehicle Vehicle { get; set; }
            public Product Product { get; set; }
            public BankingDetails BankingDetails { get; set; }
            public Company Company { get; set; }
            public cBatchNumber VehicleTyre1 { get; set; }
            public cBatchNumber VehicleTyre2 { get; set; }
            public cBatchNumber VehicleTyre3 { get; set; }
            public cBatchNumber VehicleTyre4 { get; set; }
            public cBatchNumber VehicleTyre5 { get; set; }
        }
        public class Transaction
        {
            public string PolicyId { get; set; }
            public string PolicyNumber { get; set; }
            private DateTime _InceptionDate { get; set; }
            public string InceptionDate
            {
                get { return _InceptionDate.ToString("dd-MMM-yyyy"); }
                set { _InceptionDate = DateTime.ParseExact(value, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public string GroupId { get; set; }
            public string GroupCode { get; set; }
            public string GroupName { get; set; }
            public string BranchId { get; set; }
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
            public string BranchPOAddressLine1 { get; set; }
            public string BranchPOAddressLine2 { get; set; }
            public string BranchPOAddressSuburb { get; set; }
            public string BranchPOAddressCity { get; set; }
            public string BranchPOAddressPostCode { get; set; }
            public string BranchPHAddressLine1 { get; set; }
            public string BranchPHAddressLine2 { get; set; }
            public string BranchPHAddressSuburb { get; set; }
            public string BranchPHAddressCity { get; set; }
            public string BranchPHAddressPostCode { get; set; }
            public string BranchTelephoneCode { get; set; }
            public string BranchTelephoneNumber { get; set; }
            public string BranchFaxCode { get; set; }
            public string BranchFaxNumber { get; set; }
            public string docFinanceCompanyCode { get; set; }
            public string docFinanceCompanyName { get; set; }
            public string docFinanceAccountNumber { get; set; }
            public string docInsuranceCompanyCode { get; set; }
            public string docInsuranceCompanyName { get; set; }
            public string docInsuranceAccountNumber { get; set; }
            public decimal DepositValue { get; set; }
            public decimal FinanceAmount { get; set; }
            public string ResidualValue { get; set; }
            public string BusinessManagerId { get; set; }
            public string BusinessManager { get; set; }
            public string BMWorkTelephone { get; set; }
            public string BMMobileNumber { get; set; }
            public string BMEmailAddress { get; set; }
            public string Notes { get; set; }
            public string FinanceTerm { get; set; }
            public string SalesPersonId { get; set; }
            public string SalesPerson { get; set; }
            public string InterestRateType { get; set; }
            public decimal InterestRate { get; set; }
            public string DigitallySigned { get; set; }
            public string CompanyConsent { get; set; }
            public string OtherCompanyConsent { get; set; }
            public string MarketingConsent { get; set; }
            public string LegitimateInterestConsent { get; set; }
            public string FinancePromotionCode { get; set; }
            public string IncludedSchedule { get; set; }
            public string MedicalAidScheme { get; set; }
            public string MedicalAidNumber { get; set; }
            public string EmergencyContactName1 { get; set; }
            public string EmergencyContactNumber1 { get; set; }
            public string EmergencyContactName2 { get; set; }
            public string EmergencyContactNumber2 { get; set; }
            public string CashTransaction { get; set; }
            public string finContractStartDate { get; set; }
            public string finFirstDebitDate { get; set; }
            public string POPIConcent { get; set; }
            public string VehicleUse { get; set; }
            public string LatestReferenceNumber { get; set; }
            public string LatestAlternativeReferenceNumber { get; set; }
            public string LatestAccountNumber { get; set; }
            public string DealerOwnerCode { get; set; }
            public string PackageCode { get; set; }
            public string FspCompanyName { get; set; }
            public string FspCompanyNumber { get; set; }
            public string GroupBranchRegistrationNumber { get; set; }
        }
        public class Client
        {
            public string ClientCategory { get; set; }
            public string ClientTitle { get; set; }
            public string ClientFirstName { get; set; }
            public string ClientLastName { get; set; }
            public string ClientIDType { get; set; }
            public string ClientIDNumber { get; set; }
            public string ClientGender { get; set; }
            public string ClientMobileNumber { get; set; }
            public string ClientWorkTelephoneCode { get; set; }
            public string ClientWorkTelephoneNumber { get; set; }
            public string ClientHomeTelephoneCode { get; set; }
            public string ClientHomeTelephoneNumber { get; set; }
            public string ClientEmailAddress { get; set; }
            public string ClientOccupationName { get; set; }
            public string ClientPOAddressLine1 { get; set; }
            public string ClientPOAddressLine2 { get; set; }
            public string ClientPOAddressSuburb { get; set; }
            public string ClientPOAddressCity { get; set; }
            public string ClientPOAddressPostCode { get; set; }
            public string ClientPOAddressProvinceName { get; set; }
            public string ClientPOAddressCountryName { get; set; }
            public string ClientPHAddressLine1 { get; set; }
            public string ClientPHAddressLine2 { get; set; }
            public string ClientPHAddressSuburb { get; set; }
            public string ClientPHAddressCity { get; set; }
            public string ClientPHAddressPostCode { get; set; }
            public string ClientPHAddressProvinceName { get; set; }
            public string ClientPHAddressCountryName { get; set; }
            public string MaritalStatus { get; set; }
            public string ClientEmploymentType { get; set; }
            public string ClientPassportIssueDate { get; set; }
            public string ClientPassportExpiryDate { get; set; }
            private DateTime _ClientBirthDate { get; set; }
            public string ClientBirthDate
            {
                get { return _ClientBirthDate.ToString("dd-MMM-yyyy"); }
                set { _ClientBirthDate = DateTime.ParseExact(value, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public string ContactMethod { get; set; }
        }
        public class Vehicle
        {
            public string StockNumber { get; set; }
            public string MMCode { get; set; }
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string NewUsed { get; set; }
            private DateTime _FirstRegistrationDate { get; set; }
            public string FirstRegistrationDate
            {
                get { return _FirstRegistrationDate.ToString("dd-MMM-yyyy"); }
                set { _FirstRegistrationDate = DateTime.ParseExact(value, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public string RegistrationNumber { get; set; }
            public string VINNumber { get; set; }
            public string EngineNumber { get; set; }
            public int OdometerReading { get; set; }
            public decimal RetailPrice { get; set; }
            public decimal DiscountAmount { get; set; }
            public string RegistrationFee { get; set; }
            public string DeliveryFee { get; set; }
            public string Accessories { get; set; }
            public decimal AccessoryTotal { get; set; }
            public decimal VehicleValue { get; set; }
            public string InspectorName { get; set; }
            public string VehicleDamage { get; set; }
            public string LeftFrontFenderDamage { get; set; }
            public string LeftFrontDoorDamage { get; set; }
            public string LeftBackFenderDamage { get; set; }
            public string LeftBackDoorDamage { get; set; }
            public string RightFrontFenderDamage { get; set; }
            public string RightFrontDoorDamage { get; set; }
            public string RightBackFenderDamage { get; set; }
            public string RightBackDoorDamage { get; set; }
            public string BonnetDamage { get; set; }
            public string RoofDamage { get; set; }
            public string BootDamage { get; set; }
            public string FrontBumperDamage { get; set; }
            public string BackBumperDamage { get; set; }
            public string FullServiceHistory { get; set; }
        }
        public class Product
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductOptionId { get; set; }
            public string ProductOptionCode { get; set; }
            public string ProductOptionName { get; set; }
            public decimal ProductAmount { get; set; }
            public decimal ProductVATAmount { get; set; }
            public decimal ProductTotalAmount { get; set; }
            public decimal PayoverAmount { get; set; }
            public decimal PayoverVATAmount { get; set; }
            public decimal PayoverTotalAmount { get; set; }
            public string CommissionAmount { get; set; }
            public string CollectionFee { get; set; }
            public string PaymentType { get; set; }
            public string MonthlyPremium { get; set; }
            public string CoverAmount { get; set; }
            public string Term { get; set; }
            public string ExpiryDate { get; set; }
            public string mtnExpiryKilometres { get; set; }
            public string mtnManufacturerPlanType { get; set; }
            public string mtnManufacturerExpiryMonths { get; set; }
            public string mtnManufacturerExpiryKilometres { get; set; }
            public string warAdditionalMonths { get; set; }
            public string warManufacturerExpiryMonths { get; set; }
            public string SIFirstName { get; set; }
            public string SILastName { get; set; }
            public string SIIDType { get; set; }
            public string SIIDNumber { get; set; }
            public string SIGender { get; set; }
            public string SIMobileNumber { get; set; }
            public string SIWorkTelephoneCode { get; set; }
            public string SIWorkTelephoneNumber { get; set; }
            public string SIHomeTelephoneCode { get; set; }
            public string SIHomeTelephoneNumber { get; set; }
            public string SIEmailAddress { get; set; }
            public string SIAddressLine1 { get; set; }
            public string SIAddressLine2 { get; set; }
            public string SIAddressSuburb { get; set; }
            public string SIAddressCity { get; set; }
            public string SIAddressPostCode { get; set; }
            public string SIAddressProvinceName { get; set; }
            public string SIAddressCountryName { get; set; }
            public string FirstDebitDate { get; set; }
            public string FirstDebitAmount { get; set; }
            public string RecurringDebitDay { get; set; }
            public string RecurringDebitAmount { get; set; }
            public string CollectionAgent { get; set; }
            public decimal ProductPolicyFee { get; set; }
            public string ReferenceNo { get; set; }
            public decimal ProductInspectionFee { get; set; }
            public string mtnExistingPlanType { get; set; }
            public string mtnExistingExpiryDate { get; set; }
            public string mtnExistingExipryKilometrs { get; set; }
            public string warManufacturePlan { get; set; }
            public string warManufacturerExpiryKilometres { get; set; }
            public string warExistingPlan { get; set; }
            public string warExistingExpiryDate { get; set; }
            public string warExistingExpiryKilometres { get; set; }
            public string warAdditionalKilometres { get; set; }
            public string warExpiryKilometres { get; set; }
            public string SITitle { get; set; }
            public string SIRelationship { get; set; }
            public string ProductTypeCatergoryCode { get; set; }
            public string ProductTypeCatergoryName { get; set; }
            public string ProductOwner { get; set; }
            public string ProductAdministrator { get; set; }
            public string SIBirthDate { get; set; }
            public string ProductClaimsCompany { get; set; }
            public string ProductUnderwriterCompany { get; set; }
            public decimal ProductAdminFee { get; set; }
            public decimal BinderFee { get; set; }
            public decimal DealerDocumentationFee { get; set; }
            public decimal ValuationFee { get; set; }
            public string ProductNote { get; set; }
            public decimal SupplierRecovery { get; set; }
            public string BillToCompanyName { get; set; }
            public string OptionDisclosure { get; set; }
            public string OptionQuoteNumber { get; set; }
            private DateTime _Commencement { get; set; }
            public string Commencement
            {
                get { return _Commencement.ToString("dd-MMM-yyyy"); }
                set { _Commencement = DateTime.ParseExact(value, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture); }
            }
            public string mtnKilometresCommencement { get; set; }
            public string mtnAdditionalKilometres { get; set; }
            public string BeneficiaryFirstName { get; set; }
            public string BeneficiaryLastName { get; set; }
            public string BeneficiaryIDType { get; set; }
            public string BeneficiaryIDNumber { get; set; }
            public string BeneficiaryMobileNumber { get; set; }
            public string BeneficiaryWorkTelephoneCode { get; set; }
            public string BeneficiaryWorkTelephoneNumber { get; set; }
            public string BeneficiaryHomeTelephoneCode { get; set; }
            public string BeneficiaryHomeTelephoneNumber { get; set; }
            public string BeneficiaryRelationship { get; set; }
        }
        public class BankingDetails
        {
            public string BankName { get; set; }
            public string BankBranchName { get; set; }
            public string BankBranchCode { get; set; }
            public string BankAccountType { get; set; }
            public string BankAccountNumber { get; set; }
            public string AccountHolderName { get; set; }
        }
        public class Company
        {
            public string CompanyName { get; set; }
            public string CompanyRegistrationNumber { get; set; }
            public string CompanyVATNumber { get; set; }
            public string CompanyAddressLine1 { get; set; }
            public string CompanyAddressLine2 { get; set; }
            public string CompanyAddressSuburb { get; set; }
            public string CompanyAddressCity { get; set; }
            public string CompanyAddressPostCode { get; set; }
            public string CompanyAddressProvinceName { get; set; }
            public string CompanyAddressCountryName { get; set; }
        }
        public class cBatchNumber
        {
            public string BatchNumber { get; set; }
        }
    }
