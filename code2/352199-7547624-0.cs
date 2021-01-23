    public List<Member> GetMembers()
    {
        using(DataClassesDataContext db = new DataClassesDataContext())
        {
            var members = from member in db.Members                            
            where (Convert.ToDouble(member.Latitude) - curLatitude) < 0.005
                && (Convert.ToDouble(member.Longitude) - curLongitude) < 0.005
            select member;
            return members.ToList();
        }
    }
