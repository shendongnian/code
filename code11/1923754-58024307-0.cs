/// THIS PROPERTY TRIES TO RETURN ITSELF!!
internal Version Version {
  get {
    return this.Version; // you wanted to return 'this.version'
  }
}
You can use auto-properties like this:
// No more private fields
public class UpdateXml
{
  public Version Version { get; set; }
  public string FileName { get; } // Only expose a getter, can be set in the ctor
  public Uri Uri { get; set; }
  // add more properties here...
  public UpdateXml(string filename)
  {
    FileName = filename;
  }
}
Or learn to use a convention seen allot in C#. Prefix the private variable names:
public class UpdateXml
{
  private Version _version;
  private string _fileName;
  private Uri _uri;
  public Version Version => _version;
  public string FileName => _filename;
  public Uri Uri {
    get => _uri;
    set => _uri = value;
  }
  // add more properties here...
  // use the ctor to set some field values
  public UpdateXml(string filename)
  {
    _filename = filename;
  }
  // fields allow setting values later on
  public void SetLatestVersion(Version v)
  {
    if (_version == null || v > _version)
      _version = v;
  }
}
All in all, take care when writing code. Case does matter ;-)
