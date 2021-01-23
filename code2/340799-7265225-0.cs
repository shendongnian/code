    public static List<Member> GetModifiedRecords(List<Member> localMemberData, List<Member> remoteMemberData )
        {
            var list = new List<Member>();
            foreach (var item in localMemberData)
            {
                var remoteItems = remoteMemberData.Where(q => q.Id == item.Id);
                if (remoteItems.Any())
                {
                    var remoteItem = remoteItems.First();
                    if (item.CompareTo(remoteItem) != 0) list.Add(item);
                }
            }
            return list;
        }
        public class Member : IComparable<Member>
        {
            public int Id { get; set; }
            public string Card { get; set; }
            public DateTime DateJoined { get; set; }
            public string PostalCode { get; set; }
            // TODO: add other properties
            public int CompareTo(Member other)
            {
                if (this.Card != other.Card) return 1;
                if (this.DateJoined != other.DateJoined) return 1;
                if (this.PostalCode != other.PostalCode) return 1;
                // TODO: add other properties
                return 0;
            }
        }
