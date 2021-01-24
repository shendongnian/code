		[HttpGet("[action]")]
		public string GET(object[] objects)
		{
			string param1 = objects[0] as string;
			string param2 = objects[1] as string;
			try
			{
				var url = BuildUri(param1, param2);
			}
		}
Also you should not use try blocks without catch blocks. I hope this helps
