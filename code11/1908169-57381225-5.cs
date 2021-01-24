    public sealed class Person : IDynamicMetaObjectProvider {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GetAge() {
            return DateTime.Today.Year - BirthDate.Year;
        }
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) {
            return new PersonMetaObject(parameter, this);
        }
    }
