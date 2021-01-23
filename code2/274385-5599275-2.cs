	using (SpssDataDocument spssDoc = SpssDataDocument.Create("test.sav")) { 
		SpssVariable v = new SpssNumericVariable(); 
		v.Name = "gender"; 
		v.Label = "What is your gender?"; 
		v.ValueLabels.Add(1, "Male"); 
		v.ValueLabels.Add(2, "Female"); 
		doc.Variables.Add(v); 
		doc.CommitDictionary();
		SpssCase c = doc.Cases.New();
		c["gender"] = 1;
		c.Commit();
	}
