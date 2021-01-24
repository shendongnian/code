     public class A:IComparable<B>
            {
                public string title;
                public DateTime publishDate;
                public string Author;
                public int numberOfSales;
                public int CompareTo(B other)
                {
                    if (this.numberOfSales == other.numberOfSales && this.publishDate.Equals(other.publishDate))
                        return 0;
                    if (this.numberOfSales != other.numberOfSales && this.publishDate.Equals(other.publishDate))
                        return 1;
                    if (this.numberOfSales == other.numberOfSales && !this.publishDate.Equals(other.publishDate))
                        return 2;
                    return -1;
                }
            }
            public class B
            {
                public DateTime publishDate;
                public int numberOfSales;
            }
