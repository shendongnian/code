    public class InvoiceGrouping : IEquatable<InvoiceGrouping>
    {
         public string InvoiceNum { get; set; }
         public string InvoiceLineNum { get; set; }
         public bool Equals( InvoiceGrouping other )
         {
             return other != null 
                    && this.InvoiceNum == other.InvoiceNum
                    && this.InvoiceLineNum == other.InvoiceLineNum;
         }
         public override bool Equals( object other )
         {
             return Equals( other as InvoiceGrouping );
         }
         public override int GetHashCode()
         {
             unchecked
             {
                int hash = 17;
                hash *= (this.InvoiceNum != null ? 23 + this.InvoiceNum.GetHashCode() : 1);
                hash *= (this.InvoiceLineNum != null ? 23 + this.InvoiceLineNum.GetHashCode() : 1 );
                return hash;
             }
         }
     }
     var groupedData = from row in salesTable.AsEnumerable()                   
                       group row by new InvoiceGrouping
                       {
                            InvoiceNum = row.Field<string>("InvoiceNum"),
                            InvoiceLineNum = row.Field<string>("InvoiceLineNum")
                       }
                       into grp
                       select grp;
