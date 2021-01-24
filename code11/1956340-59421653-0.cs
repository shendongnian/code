    public class ContactDetail
    {
        public string BKPLZ { get; set; }
        public string Action { get; set; }
        public string GBDEP { get; set; }
        public string PERNR { get; set; }
        public string AddressType { get; set; }
        public string BKORT { get; set; }
    }
    
    public class ContactDetails
    {
        public List<ContactDetail> ContactDetail { get; set; }
    }
    
    public class BankDetail
    {
        public string ZBANKGRP { get; set; }
        public string EMFTX { get; set; }
        public string BANKN { get; set; }
        public string Action { get; set; }
        public string PERNR { get; set; }
        public string ZZIFSC { get; set; }
        public string ZLSCH { get; set; }
    }
    
    public class BankDetails
    {
        public BankDetail BankDetail { get; set; }
    }
    
    public class BasicDetail
    {
        public string ANREX { get; set; }
        public string GBLND { get; set; }
        public string PLANS { get; set; }
        public string FRO { get; set; }
        public string Action { get; set; }
        public string BEGDA { get; set; }
        public string PERNR { get; set; }
        public string IO { get; set; }
        public string WERKS { get; set; }
        public string MASSG { get; set; }
        public string KST01 { get; set; }
        public string GSBER { get; set; }
        public string VORNA { get; set; }
        public string ORT01 { get; set; }
        public string NATIO { get; set; }
        public string NACHIN { get; set; }
        public string PERSK { get; set; }
        public string GESCH { get; set; }
        public string PERSG { get; set; }
        public string ABKRS { get; set; }
        public string BTRTAL { get; set; }
        public string GBDAT { get; set; }
        public string RO { get; set; }
        public string KBU01 { get; set; }
    }
    
    public class BasicDetails
    {
        public BasicDetail BasicDetail { get; set; }
    }
    
    public class EmployeeMasterData
    {
        public ContactDetails ContactDetails { get; set; }
        public BankDetails BankDetails { get; set; }
        public BasicDetails BasicDetails { get; set; }
    }
    
    public class EmployeeMaster
    {
        public List<EmployeeMasterData> EmployeeMasterData { get; set; }
    }
    
    public class Root
    {
        public EmployeeMaster EmployeeMaster { get; set; }
    }
    
    public class RootObject
    {
        public Root root { get; set; }
    }
