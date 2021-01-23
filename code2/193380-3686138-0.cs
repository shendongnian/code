    [JsonProperty]
    public virtual SubObject LastMemberObject {
        get {
            return MemberObjects != null
               ? MemberObjects.OrderByDescending(x => x.CreatedOn).FirstOrDefault()
               : null; }
        }
