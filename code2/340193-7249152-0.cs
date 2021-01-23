    public class Foo {
    
        public String d1;
        public String d2 { get; set; }
    
        public object getValue(String propertyName){
            var member = this.GetType().GetMember(propertyName).Single();
            if (member is PropertyInfo)
            {
                return ((PropertyInfo)member).GetValue(this, null);
            }
            else if (member is FieldInfo)
            {
                return ((FieldInfo)member).GetValue(this);
            }
            else throw new ArgumentOutOfRangeException();
        }
    }
