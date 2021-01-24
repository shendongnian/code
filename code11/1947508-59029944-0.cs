 c#
get { return LastStatusUpdate == null ? null :
    XmlConvert.ToString(LastStatusUpdate.Value, XmlDateTimeSerializationMode.Unspecified); }
and
 c#
public bool ShouldSerializeLastStatusUpdateString()
{
    return LastStatusUpdate.HasValue;
}
