    public class RolesAttribute : DataAttribute
    {
        private Role[] _roles;
        public RolesAttribute(params Role[] roles)
        {
            _roles = roles;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var data = new List<object[]>();
            //We need to add each role param to the list of object[] params
            //This will call the method for each role
            foreach(var role in _roles)
                data.Add(new object[]{role});
            return data;
        }
    }
