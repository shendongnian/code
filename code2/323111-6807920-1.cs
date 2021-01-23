    public enum RoleName : int
    {
        RegisteredUser = 7,
        Moderator = 8,
        Administrator = 9,
        Owner = 10
    }
     public List<RoleName> GetGreaterOrEqual(RoleName role)
        {
            List<RoleName> list = new List<RoleName>();
            foreach (RoleName rn in Enum.GetValues(typeof(RoleName)))
            {
                if(rn >= role)
                    list.Add(rn);
            }
            return list;
        }
