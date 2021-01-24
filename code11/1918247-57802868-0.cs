[XmlElement("field")]
public List<Field> Fields {get;} = new List<Field>();
public class Field {
    [XmlAttribute("name")]
    public string Name {get;set;}
    [XmlText]
    public string Value {get;set;}
}
---
To do this *properly* (and easily), you'd need input xml of the more typical strongly-defined form:
 xml
<startedat>2019-09-04T15:59:56.372</startedat>
<duration>8</duration>
<otherparties>1043 (DEMO BLA BLA), 0519331839</otherparties>
<switchcallid>00001000081567605580</switchcallid>
<udfs></udfs>
