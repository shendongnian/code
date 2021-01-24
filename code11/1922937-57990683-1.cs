    public class OrdiniBuoniSpesaViewModel 
        {
            public long id { get; set; }
            //OTHER VARIOUS FIELDS
            //I TRIED ALSO WITH LIST INSTEAD OF IENUMERABLE
            public IEnumerable<RigheOrdiniBuoniSpesaViewModel> RigheOrdine {get;set;}
        }
