				 var queryable = context.TransactionJournal.Where(s => s.TransactionDateTime <= transactionDate);
				 
				 if (!string.IsNullOrEmpty(your_objet.Region) 
				 {
					var queryable = queryable.Where(x=>x.Region == your_objet.Region).AsQueryable();
				 }
				 
				 if (!string.IsNullOrEmpty(your_objet.MCC) 
				 {
					var queryable = queryable.Where(x=>x.MCC == your_objet.MCC).AsQueryable();
				 }
