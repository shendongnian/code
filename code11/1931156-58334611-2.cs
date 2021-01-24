C#
public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Point obj1 = (Point)obj;
        var absX = Math.Pow(X - obj1.X, 2);
        var absY = Math.Pow(Y - obj1.Y, 2);
        var absZ = Math.Pow(Z - obj1.Z, 2);
    
        if (Math.Abs(absX + absY + absZ) >= 0.1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
We can add the group the Points using below
C#
public class PointGroup
{
    public int GroupID { get; set; }
    public Point Point1 { get; set; }
    public bool IsGrouped { get; set; }
}
C#
for (int i = 0; i < coll.Count(); i++)
{
    PointGroup pg1 = coll[i];
    if (!pg1.IsGrouped)
    {
        for (int j = 0; j < coll.Count(); j++)
        {
            PointGroup pg2 = coll[j];
            if (pg1.Point1.Equals(pg2.Point1) && pg2.IsGrouped == false)
            {
                if (pg2.GroupID == j)
                {
                    pg2.GroupID = pg1.GroupID;
                    pg2.IsGrouped = true;
                }
            }
        }
    
        pg1.IsGrouped = true;
    }
}
