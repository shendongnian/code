			// select the consignment id & name (i made up) and each matching POD
			var results = from c in consignments
			              join p in dc.PODs on c.ID equals p.Consignment into pg
			              from pgg in pg.DefaultIfEmpty()
			              select new { ID = c.ID, Name = c.Name, POD = pgg };
			// This is just a SAMPLE display just for kicks and grins
			foreach (var r in results)
			{
				Console.WriteLine(r.Name + " " + ((r.POD != null)
				                                  	? (r.POD.Consignment + " " + r.POD.Description)
				                                  	: "none"));
			}
