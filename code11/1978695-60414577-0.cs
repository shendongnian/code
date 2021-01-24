 c#
// the real property
public string InstrumentTypeCode { get; set; }
// conditional serialization
[Browsable(false)]
public bool ShouldSerializeInstrumentTypeCode() => false;
// shim property
[Browsable(false)]
public string InstrumentType {
    get => InstrumentTypeCode;
    set => InstrumentTypeCode = value;
}
