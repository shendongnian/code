c#
using Newtonsoft.Json;
namespace StackOverflow
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var json = @"{
    'id': 5002,
    'name': 'Test Recipe',
    'recipeLink': 'testlink',
    'category1Id': 7757,
    'category2Id': 7758,
    'category3Id': 7759,
    'category4Id': 7760,
    'recipeById': 1,
    'totalTime': 30,
    'totalTimeUnitId': 1,
    'activeTime': 20,
    'activeTimeUnitId': 1,
    'instructions': 'Test Instructions',
    'sourceKey': 'Test SK',
    'recipeBy': 'TestPerson',
    'insertedAtUtc': '2019-09-04T12:18:48.0466667',
    'isVerified': 1,
    'numPersons': 5
}".Replace("'", "\"");
            //This works...
            var deserialized1 = JsonConvert.DeserializeObject(json);
            //Prepend a U+FEFF Byte Order Mark character...
            json = "\uFEFF" + json;
            //This fails with error:
            //Newtonsoft.Json.JsonReaderException:
            //Unexpected character encountered while parsing value: ﻿. Path '', line 0, position 0.
            var deserialized2 = JsonConvert.DeserializeObject(json);
        }
    }
}
