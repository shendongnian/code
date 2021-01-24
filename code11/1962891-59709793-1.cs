`
		var parsedJsonObject = JsonConvert.DeserializeObject<List<ObjectName>>(jsonObject);
		var normalizedData = parsedJsonObject.SelectMany(pParent => pParent.Category, (pParent, pCategory) => 
												new { pParent, pCategory }).Select(ParentAndCategory =>
																				new
																				{
																					Cost = ParentAndCategory.pParent.Cost,
																					Category = ParentAndCategory.pCategory,
																				}).ToList();
		var aggregatedData = new List<ObjectName2>(); 
		
		for(int i = 0; i < (normalizedData.Count - 1);)
		{
			aggregatedData.Add(new ObjectName2{ Cost = normalizedData[i].Cost, Category1 = normalizedData[i].Category, Category2 = normalizedData[i + 1].Category });
			i += 2;
		}
			
		var result = aggregatedData.GroupBy(p => p.Category1)
									.Select(g => new 
											{ 
												name = g.Key, 
												data = g.GroupBy(p => p.Category2).Select(g2 => 
																						  new { name = g2.Key, value = g2.Sum(p2 => p2.Cost) })
											}).ToList();
		foreach(var item in result)
			Console.WriteLine(JsonConvert.SerializeObject(item));
`
**Output**
    {"name":"Online","data":[{"name":"Games","value":9.00},{"name":"Grocery","value":3.00}]}
    {"name":"Transport","data":[{"name":"Bus","value":6.00},{"name":"Train","value":10.00}]}
  [1]: https://dotnetfiddle.net/LmpiAY
