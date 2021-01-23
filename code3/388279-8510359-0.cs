    private List<SelectListItem> MapDegree()
    		{
    			var enumerationValues = Enum.GetValues(typeof(Degree));
    			var enumerationNames = Enum.GetNames(typeof(Degree));
    			List<List1> lists = new List<List1>();
    			foreach (var value in Enum.GetValues(typeof(Degree)))
    			{
    				List1 selectList = new List1
    				{
    					Text = value.ToString(),
    					Value = ((int)value).ToString(),
    					
    				};
    				lists.Add(selectList);
    			}
    			return lists;
    		}
