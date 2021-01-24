    public class DataItem 
    {
       public string Sheet { get; set; }
       ...
       public bool Validity { get; set; }
    }
    CMIS_Entities context = new CMIS_Entities();
    var results = context.PI_Line.Join(context.PI_Sheet, c => c.idL, x => x.idL, (c, x) => new DataItem
    {
        Sheet=x.Sh1.ToString() + "/" + c.TotalSheet.ToString(),
        Sh1=x.Sh1,
        idS=x.idS,
        idL=c.idL,
        IsoLine=x.Line3,
        SheetValidity=x.SheetValidity,
        Pos=c.Pos,
        Zone=c.Zone,
        Line=c.Line,
        WellHead=c.WellHead,
        Validity=c.RevValid
    }).ToList();
    Line_Grid.ItemsSource = results;
