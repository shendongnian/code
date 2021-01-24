 c#
[XmlRoot("string", Namespace = "https://kmc--tst3.custhelp.com/")]
public class MyRoot {
    public KMCModelExtCovPriceInquiry Inquiry {get;set;}
}
You *can* do what you want with a sub-reader, but... frankly it isn't worth the pain.
