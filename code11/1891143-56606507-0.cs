    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using HtmlAgilityPack;
    using System.IO;
    
    namespace SearchingHTML
    {
        public class CharacterData
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string Url { get; set; }
        }
        public class Program
        {
            public static CharacterData ExtractCharacterNameAndImage(string url)
            {
                var tableXpath = "/html/body//table";
                var nameXpath = "tr/td[2]/div[4]";
                var imageXpath = "tr/td[1]/div[1]/a/img";
    
                var htmlDoc = new HtmlWeb().Load(url);
                var table = htmlDoc.DocumentNode.SelectNodes(tableXpath).First();
                var name = table.SelectNodes(nameXpath).Select(n => n.GetDirectInnerText().Trim()).SingleOrDefault();
                var imageUrl = table.SelectNodes(imageXpath).Select(n => n.GetAttributeValue("src", "")).SingleOrDefault();
    
                return new CharacterData { Name = name, ImageUrl = imageUrl, Url = url };
            }
            public static void Main()
            {
                int max = 10000;
                string fileName = @"C:\Users\path of your file.json";
    
                Console.WriteLine("Environment version: " + Environment.Version);
                Console.WriteLine("Json.NET version: " + typeof(JsonSerializer).Assembly.FullName);
                Console.WriteLine("HtmlAgilityPack version: " + typeof(HtmlDocument).Assembly.FullName);
                Console.WriteLine();
    
                for (int i = 6; i <= max; i++)
                {
                    try
                    {
                        var url = "https://myanimelist.net/character/" + i;
                        var htmlDoc = new HtmlWeb().Load(url);
                        var data = ExtractCharacterNameAndImage(url);
                        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                        Console.WriteLine(json);
                        TextWriter tsw = new StreamWriter(fileName, true);
                        tsw.WriteLine(json);
                        tsw.Close();
                    } catch (Exception ex) { }
                }
    
            }
        }
    }
    
    /*******************************************************************************************************************************
     ****************************************************IF TESTING IS REQUIERED****************************************************
     *******************************************************************************************************************************
     * 
     * static void TestSelect(HtmlDocument htmlDoc, string xpath)
        
            Console.WriteLine("\nInput path: " + xpath);
            var splitPath = xpath.Split('/');
            for (int i = 2; i <= splitPath.Length; i++)
            {
                if (splitPath[i - 1] == "")
                    continue;
                var thisPath = string.Join("/", splitPath, 0, i);
                Console.Write("Testing \"{0}\": ", thisPath);
                var result = htmlDoc.DocumentNode.SelectNodes(thisPath);
                Console.WriteLine("result count = {0}", result == null ? "null" : result.Count.ToString());
            }
        }
    
      *******************************************************************************************************************************
      *********************************************FOR TESTING ENTER THIS INTO MAIN CLASS********************************************
      *******************************************************************************************************************************
      * 
      *     var url2 = "https://myanimelist.net/character/256";
            var data2 = ExtractCharacterNameAndImage(url2);
            var json2 = JsonConvert.SerializeObject(data2, Formatting.Indented);
    
            Console.WriteLine(json2);
    
            
    
            var nameXpathFromFirefox = "/html/body/div[1]/div[3]/div[3]/div[2]/table/tbody/tr/td[2]/div[4]";
            var imageXpathFromFirefox = "/html/body/div[1]/div[3]/div[3]/div[2]/table/tbody/tr/td[1]/div[1]/a/img";
            TestSelect(htmlDoc, nameXpathFromFirefox);
            TestSelect(htmlDoc, imageXpathFromFirefox);
            var nameXpathFromFirefoxFixed = "/html/body/div[1]/div[3]/div[3]/div[2]/table/tr/td[2]/div[4]";
            var imageXpathFromFirefoxFixed = "/html/body/div[1]/div[3]/div[3]/div[2]/table/tr/td[1]/div[1]/a/img";
            TestSelect(htmlDoc, nameXpathFromFirefoxFixed);
            TestSelect(htmlDoc, imageXpathFromFirefoxFixed);
    
      *******************************************************************************************************************************
      *******************************************************************************************************************************
      *******************************************************************************************************************************
      */
