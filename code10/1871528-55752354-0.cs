c#
public class ElementDTO {
    public int Number1 {get; set}
    public int Number2 {get; set}
    public int Number3 {get; set}
    public int Number4 {get; set}
    public char InputChar {get; set}
}
And read the file via StreamReader:
c#
List<ElementDTO> list = new List<ElementDTO>();
using (StreamReader sr = new StreamReader("/path/to/file"){
   string line;
   while((line = sr.ReadLine()) != null) {
   ...//here your split code
   ElementDTO element = new Element {
     Number1 = ...;
     Number2 = ...;
     Number3 = ...;
     Number4 = ...;
     InputChar = ....;
   };
   list.add(element);
   }
}
return list.ToArray();
