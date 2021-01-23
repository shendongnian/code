     public IEnumerable<BatchHeader> GetHeaders() {
         using(NSFChecksDataContext context = DataContext) {         
             foreach(var header in context.BatchHeaders) {
                 yield return header;
             }
         }
     }
