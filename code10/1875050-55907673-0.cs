c#
public class LeadPerformanceItem
{
    public string name { get; set; }
    public int visitors { get; set; }
    
    private int totalVisitors=0;
    public void UpdateTotalVisitors(int total){
        this.totalVisitors=total;
    }
    public int visitorspercentoftotal
    {
        get
        {
           if(totalVisitors!=0){
               return Math.round(((double)(visitors*100))/totalVisitors);
           }else return 0;
        }
    }
}
public class LeadPerformanceItemCollection
{
    public List<LeadPerformanceItem> items {get; private set;}
    public void AddToItems(LeadPerformanceItem item){
        
        items.add(item);
        int total= items.Sum(x => x.visitors);
        items.AsParallel().ForAll(i=> i.UpdateTotalVisitors(total));
    }
    public int totalvisitors
    {
        get
        {
            return items.Sum(x => x.visitors);
        }
    }       
}
Just add to the Items collection by calling AddToItems method 
