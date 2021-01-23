    public interface IAccount
    {
        //Below are properties and methods which you expose outside
        // accoring to your class/domain
        double Interest { get;}
        //double Balance { get;}
        //ContactInfo Contact{ get;}
        void Visit(IAccountVisitor visitor);
    }
    
    public class AccountBase
    {
    }
    
    public class FixedDeposit: AccountBase, IAccount
    {
        double Interest { 
                get{
                    return  CalculateInterest(); //don't change object state                    
                }
                        ;}
                        
        protected double CalculateInterest()
        {
            return <<your expression to calculate>>;
        }
        
        public void Visit(IAccountVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    public class XYZBlashBlahDeposit: AccountBase, IAccount
    {
        public void Visit(IAccountVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    ...
    ...
    public interface IAccountVisitor
    {
        //void Report(IAccount account); //This is prefered and safe and 
        void Visit(Account account);
    }
    
    public class PrintReportVisitor: IAccountVisitor
    {
        public void Visit(Account account)
        {
            //Get object information
            //Print to printer
        }
    }
    
    public class DisplayReportVisitor: IAccountVisitor
    {
        public void Visit(Account account)
        {
            //Get object information
            //Display on monitor
        }
    }
    
    public class ReportAudioVisitor: IAccountVisitor
    {
        public void Visit(Account account)
        {
            //Get object information
            //Read out the information
        }
    }
    
    public class SmsReportVisitor: IAccountVisitor
    {
        public void Visit(Account account)
        {
            //Get object information
            //Send SMS to my mobile registered with account
        }
    }
    
    public class EmailReportVisitor: IAccountVisitor
    {
        public void Visit(Account account)
        {
            //Get object information
            //Send Email to my email registered with account
        }
    }
