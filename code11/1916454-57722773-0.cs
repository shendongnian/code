csharp
    public class Program
      {
        public static void Main(string[] args)
        {
         var myColors = new Dictionary<string,string>();
         try{
             var connectionString = Environment.GetEnvironmentVariable("CssDBConnection");
             //select values from DB into the dictionary
             myColors = GrabCssColorsFromDatabase(connectionString);
         }catch(Exception e){
            //use default css values in the dictionary
         }
         finally{
            InjectCss(myColors);
           BuildWebHost(args).Run();
         }
          
        }
It's similar to this workaround for Nlogs non Layout Targets:
https://github.com/NLog/NLog/wiki/WebService-target---Workaround-for-url-variables
