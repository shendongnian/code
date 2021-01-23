    public static string ReturnTheNameBetweenCommas(string str)
    {
        int indexOfTheFirstComma = str.IndexOf(',');//find the first comma index
        string strAfterTheFirstComma = str.SubString(indexOfTheFirstComma +1);//take the rest after the first comma
        indexOfTheFirstComma = strAfterTheFirstComma.IndexOf(',');
        string theNameBetweenFirstTwoCommas = strAfterTheFirstComma.SubString(0,indexOfTheFirstComma-1);
      
      return strAfterTheFirstComma;       
    
    }
    
    public class NameAndOccurencce
    {
        public string Name{ get; set; }
        public int Occurence{ get; set; }
    }
    
    public static void Method()
    {
        List<string> listOfLines = new List<string>();
        //Read all the lines to listOfLines one by one, use listOfLines.Add(line) every line as an element of the list
        List<string> listOfDistinctNames = new List<string>();
        
        foreach(var item in listOfLines)
        {
             string nameInTheLine = ReturnTheNameBetweenCommas(item);
             if(!listOfDistinctNames.Contains(nameInTheLine))
             {
               listOfDistinctNames.Add(nameInTheLine);
             }
        }
        
        List<NameAndOccurence> listOfNameAndOccurence = new List<NameAndOccurence>();
        
        foreach(var nameStr in listOfDistinctNames)
        {
           NameAndOccurence nameAndOccr = new NameAndOccurence();
           int occurence = 0        
  
           foreach(var lineStr in listOfLines)
           {
               if(lineStr.Contains(nameStr))
               {
                  occurence++;
               }
               else
               {
                   nameAndOccr.Name = nameStr;
                   nameAndOccr.Occurence = occurence;
                   
                   listOfNameAndOccurence.Add(nameAndOccr);                   
               }
           }
           
        }
        //now you've got the names in the lines and how many times they occurred
        //for example for the image you showed there are 10 lines with the name of Butter-1M
        //so in your listOfNameAndOccurence you have an object like this
        //nameAndOccurence.Name is "Butter-1M" and nameAndOccurence.Occurence is 10
        //you've got one for Apple too.
        //Well after that all you gotta do is writing the 10th line of the textfile for Butter-1M
     
    }
