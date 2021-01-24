c#
TheoreticalObjects.Tube c = new TheoreticalObjects.Tube(1, "Tube", "Element", 1, 1, "tube", new Length(1, UnitsNet.Units.LengthUnit.Meter), new Length(0.1, UnitsNet.Units.LengthUnit.Meter), new Length(2, UnitsNet.Units.LengthUnit.Meter));
JsonSerializerSettings _jsonSerializerSettingsOCCServer = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = Newtonsoft.Json.Formatting.Indented };
_jsonSerializerSettingsOCCServer.Converters.Add(new UnitsNetJsonConverter());
string json = JsonConvert.SerializeObject(c, typeof(TheoreticalObjects.BaseClass), _jsonSerializerSettingsOCCServer);
The settings for the deserialization part remains the same as on my first post.
But the constructor of the binder changes:
c#
public MyBinder()
        {
            List<Type> myTypes = new List<Type>();
            Assembly[] myAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < myAssemblies.Length; i++)
            {
                if (myAssemblies[i].GetName().Name == "RealObjects")
                {
                    foreach (Type t in myAssemblies[i].GetTypes())
                    {
                        
                        if (t.IsSubclassOf(typeof(RealObjects.BaseClass)))
                        {
                            myTypes.Add(t);
                        }
                    }
                    break;
                }
            }
            foreach (var type in myTypes)
            {
                Map(type, "TheoreticalObjects."+type.Name); //this part changed
            }
        }
that way you binded to the right class (RealObjects.Tube)
I was having an instance of the class RealObjects.Tube in my construction queue
Note that I had to modify the fields in my RealObjects.Tube to be of Length type and not double type
thanks again @dbc for your help =)
