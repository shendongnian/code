    public string JsonMinusProperties(object toSerialize)
		{
			//Replace this with your preferred way of getting your unwanted properties
			var LinqMemberNames = toSerialize.GetType().GetProperties().Where(y=>
				y.GetCustomAttributes(true).Any(x =>
					x.GetType().Namespace == "System.Data.Linq.Mapping"
				)
			).Select(x=>x.Name);
			
			JavaScriptSerializer js = new JavaScriptSerializer();
			string json = js.Serialize(toSerialize);
			var tempobj = js.DeserializeObject(json) as Dictionary<string, object>;
			foreach (string linqMember in LinqMemberNames)
			{
				tempobj.Remove(linqMember);
			}
			return js.Serialize(tempobj);
		}
