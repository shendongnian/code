	var item = new
	{
		LiftPositioner = new[] 
		{ 
			new 
			{
				LiftMax = 5,
				LiftMin = 0
			}
		},
		Temperature = new[] 
		{
			new
			{
				CH0_Temp = 25,
				CH1_Temp = 25
			}
		}
	};
	string strJson = JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented);
	Console.WriteLine(strJson);
