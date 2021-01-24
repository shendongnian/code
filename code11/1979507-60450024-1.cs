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
       var obj = JsonConvert.DeserializeObject<List<Input>>(json);
       Console.WriteLine(JsonConvert.SerializeObject(obj));
       Console.ReadKey();
   }
}
public class Input
{
   public string name { get; set; }
   public List<Input> children { get; set; }
}
