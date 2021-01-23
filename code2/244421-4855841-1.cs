    interface INode {}
    class Node: INode {}
    interface IVisit
    class Visit: IVisit
    {
        Visit(INode node) {}
    }
 
    interface ISolution {}
    class Solution: ISolution
    {
       Solution(IList<IRoute> routes)
       {
       }
    }
