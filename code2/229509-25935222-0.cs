        //double.TryParse(, out bd.Budget);
		bool result = TryParse(s, value => bd.Budget = value);
	}
	public bool TryParse(string s, Action<double> setValue)
	{
		double value;
		var result =  double.TryParse(s, out value);
		if (result) setValue(value);
		return result;
	}
