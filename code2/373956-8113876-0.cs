    public abstract class Voucher
    {
    	public int Id { get; set; }
    	public decimal Value { get; protected set; }
    	public virtual string SuccessMessage { get { return "Applied"; } }
    	public virtual string FailureMessage { get { return String.Empty; } }
    	public virtual bool Ok { get { return true; } }
    }
    
    public class GiftVoucher : Voucher { }
    
    public class DiscountVoucher : Voucher
    {
    	public decimal Threshold { get; private set; }
    	public override string FailureMessage { get { return "Please spend £{0} to use this discount"; } }
    	public override bool Ok { get { return Value >= Threshold; } }
    }
