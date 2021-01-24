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
**If you want to update it on the fly (no new Deployment).**
Provide an IActionResultEndpoint which returns the injected CssFile.
The Endpoint could be /Home/Styles
And again:
 1. Grab Variables from Database, or fallback values
 2. Grab your "cssTemplate"
 3. Inject the variables
 4. Return the generated css file (as FileResult)
 5. You UI should grab the styles from this endpoint then instead of an file
