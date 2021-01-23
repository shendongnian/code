        var typeStrings = new Dictionary<Int16, String>();
        var fields = this.GetType().GetFields();
        foreach (var field in fields)
        {
            try
            {
                typeStrings.Add(Convert.ToInt16(field.FieldHandle.Value.ToInt32().ToString()), field.Name);
            }
            catch (Exception)
            {
                throw;
            }
        }
