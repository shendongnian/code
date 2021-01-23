			// select the Consignment ID and Name (i made up), and list of PODs
			// instead of the individual POD
			var results = from c in consignments
			              join p in dc.PODs on c.ID equals p.Consignment into pg
			              select new { ID = c.ID, Name = c.Name, PODs = pg };
			// This is just a SAMPLE display just for kicks and grins
			foreach (var r in results)
			{
				Console.WriteLine(r.Name + " ");
				if (r.PODs.Count() > 0)
				{
					foreach (var pod in r.PODs)
					{
						Console.WriteLine("\t" + pod.Consignment + " " + pod.Description);
					}
				}
				else
				{
					Console.WriteLine("\tNone");
				}
			}
