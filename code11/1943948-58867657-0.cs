cs
public void CalculateAPR()
{
    if(Interest != 0) {
        Total = "£" + (Loan * Length) / Interest;
    } else {
        Total = "£ -";
    }
}
Second solution:
cs
private int? intRate { get; set; }
public int? Interest
{
    get => intRate;
    set {
        intRate = value;
        OnPropertyChanged("Interest");
        CalculateAPR();
    }
}
public void CalculateAPR()
{
    Total = "£" + (Loan * Length) / (Interest??1);
}
Depending on how you expect the total label to look like, if your interest is not filled yet. 
