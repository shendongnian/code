class Program
{
   static void Main(string[] args)
   {
       string json = @"[{
                'name': 'AML Policy',
                'children': [{
                     'name': 'Test',
                     'children': [{
                          'name': 'Test123',
                          'children': []
                           }]
                    }]
                },
                {
                    'name': 'AML Policy2',
                    'children': []
                }]";
       var obj = JsonConvert.DeserializeObject<IEnumerable<Input>>(json);
       Console.WriteLine(JsonConvert.SerializeObject(obj));
       Console.ReadKey();
   }
}
public class Input
{
   public string Name { get; set; }
   public List<Input> Children { get; set; }
}
