         public abstract class DataField
            {
                    public string Name { get; set; }
            }
            public class DataField<T> : DataField
            {
                    public T Value { get; set; }
                    public Type GenericType { get { return this.Value.GetType(); } }
            }
            static Func<XElement , DataField> dfSelector = new Func<XElement , DataField>( e =>
            {
                    string strType = e.Attribute( "type" ).Value;
                    //if you dont have an attribute type, you could call an extension method to figure out the type (with regex patterns)
                    //that would only work for struct
                    Type type = Type.GetType( strType );
                    dynamic df = Activator.CreateInstance( typeof( DataField<>).MakeGenericType( type ) );
                    df.Name = e.Attribute( "name" ).Value;
                    dynamic value = Convert.ChangeType( e.Value , type );
                    df.Value = value;
                    return df;
            } );
            public static List<DataField> ConvertXML( string xmlstring )
            {
                    var result = XDocument.Parse( xmlstring )
                                            .Root.Descendants("object")
                                            .Select( dfSelector )
                                            .ToList();
                    return result;
            }
            static void Main( string[] args )
            {
                    string xml = "<root><object name=\"im1\" type=\"System.String\">HelloWorld!</object><object name=\"im2\" type=\"System.Int32\">324</object></root>";
                    List<DataField> dfs = ConvertXML( xml );
            }
