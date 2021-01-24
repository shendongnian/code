            var results = new List<Thing>();
			var ids = new List<long>() { 1, 2, 3, 4, 5, 6 };
            var batch = new ODataBatch(_client);
            foreach (var id in ids)
            {
	            batch += async c =>
	            {
                    Thing result;
		            result = await c.For<Thing>().Key(id).FindEntryAsync();
                    if (result != null) {
                        results.Add(result);
                    }
	            };
            }
            await batch.ExecuteAsync();
