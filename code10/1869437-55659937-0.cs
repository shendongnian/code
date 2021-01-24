    `private static void writeDataTest(List<Metadata> records)
        {
                 ......
               csv.Configuration.ShouldQuote = (field, context) =>
               {
                    return false;
               };
               ......
         } 
         public class MetadataMap : ClassMap<Metadata>
        { .....
             Map(m => m.Email).Index(4).ConvertUsing(m => m.Email != null ? $"\"{m.Email}\"" : $"{m.Email}"); 
        ....} 
`
