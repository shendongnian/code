    var result = A_TABLE
			.GroupJoin(B_Table,
				a => a.Id,
				b => b.A_TABLE_Id,
				(a, b) => new { a.ColumnName, b.ColumnName, ... })
			.GroupJoin(C_Table,
				bb => bb.b.Id,
				c => c.B_TABLE_Id,
				(b,c) => new { b.ColumnName, c.ColumnName, ... })
				.ToList();
