    public partial class Line
    {
        public static Expression<Func<Line,Decimal>> TotalExpression
        {
            get
            {
                return l => l.Price * l.Quantity
            }
        }
    }
