 c#
    private int? _size;
    [XmlAttribute]
    public int Size
    {
        get => _size.GetValueOrDefault();
        set => _size = value;
    }
    public bool ShouldSerializeSize() => _size.HasValue;
    private decimal? _weight;
    [XmlAttribute]
    public decimal Weight
    {
        get => _weight.GetValueOrDefault();
        set => _weight = value;
    }
    public bool ShouldSerializeWeight() => _weight.HasValue;
With this, the serializer *basically* does (pseudo-code):
 c#
if (obj.ShouldSerializeSize()) output.WriteAttribute("Size", obj.Size);
if (obj.ShouldSerializeWeight()) output.WriteAttribute("Weight", obj.Weight);
You could also use other rules like "only serialize if positive", i.e.
 c#
[XmlAttribute]
public int Size {get;set;}
public bool ShouldSerializeSize() => Size > 0;
