public int AdjacentShapeNum { get; set; }
public bool IsAdjacentTo(TriangleRegistryList other)
{
   var isAdjacentTo = 
            GetPoints().Intersect(other.GetPoints()).ToList().Count() >= 2;
            if(isAdjacentTo){
                this.AdjacentShapeNum = other.ShapeNum;
            }
            return isAdjacentTo;
}
