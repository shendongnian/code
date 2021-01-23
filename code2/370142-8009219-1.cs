            public override string ToString()
            {
                var props = GetType().GetProperties();
                string result = "";
                foreach (var prop in props)
                {
                    var val = prop.GetValue(this, null);
                    var strVal = val != null ? val.ToString() : string.Empty;
                    result += prop.Name + " : " + strVal + Environment.NewLine;
                }
                return result;
            }
        }
