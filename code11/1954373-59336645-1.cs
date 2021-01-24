c#
"name=\"xsrf.token\" value=\""
and string `end` = 
c#
"\""
Then:
c#
static string GetBetween(string message, string start, string end)
        {
            //Required to handle possible problems that will arise due to indexing if the string does not exist
            try{
                //Splits the original message by the character array of the string "start", then takes the second index of that string array
                string splitmessage = message.Split(new string[] {start})[1]
                //Splits the remaining message by the character array of string "end", then takes the first index of that string array
                splitmessage = message.Split(new string[] {end})[0]
                return splitmessage;
            } catch(Exeption ex){
                //Handle when the string you're attempting to find is not there
            }
        }
Should return only the value of the input you are looking for.
You will have to handle what happens when that value is not found separately.
