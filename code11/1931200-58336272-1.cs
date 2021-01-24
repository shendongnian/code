using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
(...)
var carGroups = cars
    .GroupBy(c => c.Color) // You can modify the key here: .GroupBy(c => "Color:"+c.Color)
    .ToDictionary(g => g.Key);
var json = JsonConvert.SerializeObject(carGroups, Formatting.Indented);
Console.WriteLine(json);
outputs
{
  "blue": [
    {
      "Make": "Honda",
      "Model": "Accord",
      "Color": "blue"
    },
    {
      "Make": "Honda",
      "Model": "Civic",
      "Color": "blue"
    }
  ],
  "green": [
    {
      "Make": "Dodge",
      "Model": "Caravan",
      "Color": "green"
    }
  ],
  "red": [
    {
      "Make": "Ford",
      "Model": "Crown Victoria",
      "Color": "red"
    }
  ]
}
