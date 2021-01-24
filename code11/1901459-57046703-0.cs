C#
void Main()
{
	DataTable Designs = new DataTable();
	Designs.Columns.Add("DesignGroupId", typeof(Guid));
	Designs.Rows.Add(Guid.NewGuid());
	Designs.Rows.Add(Guid.NewGuid());
	Designs.Rows.Add(Guid.NewGuid());
	Designs.Rows.Add(Guid.Parse("7c176832-593c-402f-9def-fbe12da3742f"));
	
	List<Guid> values = new List<Guid>();
	values.Add(Guid.NewGuid());
	values.Add(Guid.NewGuid());
	values.Add(Guid.NewGuid());
	//values.Add(Guid.Parse("7c176832-593c-402f-9def-fbe12da3742f"));
	var res = Designs.AsEnumerable().Where(row => values.Contains(row.Field<Guid>("DesignGroupId"))).ToList();
	  if (res.Count > 0 )
	  	Designs =  res.CopyToDataTable();
	  else
	  	Designs.Clear();
}
