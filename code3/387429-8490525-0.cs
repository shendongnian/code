    public class RefContainer {
        // maybe RefID is not an int...?
        public Int32 RefID { get; set; }
    }
    Session["WorkingList"] = q.Select(x => new RefContainer { RefID = x.RefID });
    var workingList = Session["WorkingList"] as IEnumerable<RefContainer>;
    if (workingList != null) {
        var nextRecord = workingList
            .SkipWhile(i => i.RefID != currentRecord)
            .Skip(1).First();
    }
