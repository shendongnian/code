public class EquipmentDTO: EncodableDTO
{
  private int id;
  public string Id {
    get
  	{
  	  return GetIdValue(id);
  	}
  	set
  	{
  	  id = SetIdValue(value);
  	}
  }
  public List<PartDTO> Parts {get; set;}
  public string Name {get; set;}
}
public class PartDTO: EncodableDTO
{
  private int id;
  public string Id {
    get
  	{
  	  return GetIdValue(id);
  	}
  	set
  	{
  	  id = SetIdValue(value);
  	}
  }
  public string Name {get; set;}
}
public class EncodableDTO
{
    public EncodableDTO()
    {
        // encode models by default
        isEncoded = true;
    }
    public bool isEncoded { get; private set; }
    public void Decode()
    {
        isEncoded = false;
        RunEncodableMethodOnProperties(MethodBase.GetCurrentMethod().Name);
    }
    public void Encode()
    {
        isEncoded = true;
        RunEncodableMethodOnProperties(MethodBase.GetCurrentMethod().Name);
    }
    protected string GetIdValue(int id)
    {
        return isEncoded ? Utils.EncodeParam(id) : id.ToString();
    }
    // TryParseInt() is a custom string extension method that does an int.TryParse and outputs the parameter if the string is not an int
    protected int SetIdValue(string id)
    {
        // check to see if the input is an encoded value, otherwise try to parse it.
        // the added logic to test if the 'id' is an encoded value allows the inheriting DTO to be received both in
        // unencoded and encoded forms (unencoded/encoded http request) and still populate the correct numerical value for the ID
        return id.TryParseInt(-1) == -1 ? Utils.DecodeParam(id) : id.TryParseInt(-1);
    }
    private void RunEncodableMethodOnProperties(string methodName)
    {
        var self = this;
        var selfType = self.GetType();
        // Loop through properties and check to see if any of them should be encoded/decoded
        foreach (PropertyInfo property in selfType.GetProperties())
        {
            var test = property;
            // if the property is a list, check the children to see if they are decodable
            if (property is IList || (
                    property.PropertyType.IsGenericType
                    && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)
                    || property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
                    )
                )
            {
                var propertyInstance = (IList)property.GetValue(self);
                if (propertyInstance == null || propertyInstance.Count == 0)
                {
                    continue;
                }
                foreach (object childInstance in propertyInstance)
                {
                    CheckIfObjectEncodable(childInstance, methodName);
                }
                continue;
            }
            CheckIfObjectEncodable(property.GetValue(self), methodName);
        }
    }
    private void CheckIfObjectEncodable(object instance, string methodName)
    {
        if (instance != null && instance.GetType().BaseType == typeof(EncodableDTO))
        {
            // child instance is encodable. Run the same decode/encode method we're running now on the child
            var method = instance.GetType().GetMethod(methodName);
            method.Invoke(instance, new object[] { });
        }
    }
}
An alternative to `RunEncodableMethodOnProperties()` was the explicitly decode/encode child properties in the inheriting class:
public class EquipmentDTO: EncodableDTO
{
  private int id;
  public string Id {
    get
  	{
  	  return GetIdValue(id);
  	}
  	set
  	{
  	  id = SetIdValue(value);
  	}
  }
  public List<PartDTO> Parts {get; set;}
  public string Name {get; set;}
  public new void Decode() {
    base.Decode();
    // explicitly decode child properties
    Parts.ForEach(p => p.Decode());
  }
}
I chose not to do the above because it created more work for DTO creators to have to remember to explicitly add (1) the override method, and (2) any new decodable properties to the override method. That being said, I'm sure I'm taking some sort of a performance hit by looping through every class of my class' properties and its children, so in time I may have to migrate towards this solution instead.
Regardless of the method I chose to decode/encode properties, here was the end result in the controllers:
// Sample controller method that does not support encoded output
[HttpPost]
public async Task<IHttpActionResult> AddEquipment([FromBody] EquipmentDTO equipment)
{
    // EquipmentDTO is 'isEncoded=true' by default
    equipment.Decode();
    // send automapper the interger IDs (stored in a string)
    var serviceModel = Mapper.Map<EquipmentVO>(equipment);
    var addedServiceModel = myService.AddEquipment(serviceModel);
    var resultValue = Mapper.Map<EquipmentDTO>(addedServiceModel);
    resultValue.Decode();
    return Created("", resultValue);
}
// automapper
CreateMap<EquipmentVO, EquipmentDTO>().ReverseMap();
CreateMap<Equipment, EquipmentVO>();
While I don't think its the cleanest solution, it hides a lot of the necessary logic to make encoding/decoding work with the least amount of work for future developers
