    class Claim : DynamicObject 
    {
        ... // Current definition
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                var property = typeof(Loan).GetProperty(binder.Name);
                object param = null;
                // Find some way to parse the string into a value of appropriate type:
                // (This will of course need to be improved to handle more types)
                if (property.PropertyType == typeof(Int32) )
                {
                    param = Int32.Parse(value.ToString());
                }
                // Set property in the corresponding Loan object
                property.SetValue(GetLoan(this), param, null);
                db.Save();
            }
            catch
            {
                return base.TrySetMember(binder, value);
            }
            return true;
        }
    }
