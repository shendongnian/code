     public class Data
            {
                public string Index { get; set; }
                public string Letter { get; set; }
            }
    string data = "G9999999990001800002777107050,G9999999990002777107HMNLAQKPRLLHRAQRWJ010,1,3,29,P,6.74,11.23,07,P,5.25,14.29,08,P,6.89,16.92,2,5,052,U,4.78,31.04,095,O,9.59,27.63,076,P,3.85,16.50,094,P,4.84,18.30,093,O,8.28,26.90,062,P,4.64,16.00,061,P,2.84,12.87,090,O,7.90,20.83,050,P,3.36,16.59,057,B,12.05,34.46,1,1,111,P,7.26,13.79";
    
                var elements = data.Split(',');
    
                int counter = 1;
                int startIndex = 2;
                int dataBlock=0;
                Dictionary<int, List<Data>> result = new Dictionary<int,List<Data>>();
    
                while(elements.Length > startIndex)
                {
                    dataBlock = int.Parse(elements[startIndex]) * int.Parse(elements[startIndex+1]);
                    startIndex +=2;
                    for(int i=0;i<dataBlock;i++)
                    {
                        Data d = new Data(){Index = elements[startIndex], Letter = elements[startIndex+1]};
                        if (result.ContainsKey(counter))
                            result[counter].Add(d);
                        else
                        {
                            result.Add(counter, new List<Data>());
                            result[counter].Add(d);
                        }
    
                        startIndex+=4;
                    }
                    counter++;
                }
