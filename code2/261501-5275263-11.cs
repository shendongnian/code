    public class ObjectDTO
    {
        public ObjectFromDB BaseObject { get; set; }
        public int Id 
        {
            get { return BaseObject.Id; }
        }
        public string Name 
        {
            get { return BaseObject.Name; }
        }
        public string C1D
        {
            get
            {
                if (BaseObject.C1SC.HasValue && BaseObject.C1SC < DateTime.Now.AddDays(-183)) return "Green";
                return string.Empty;
            }
        }
        public string C2D
        {
            get
            {
                if (BaseObject.C2SC.HasValue && BaseObject.C2SC < DateTime.Now.AddDays(-183)) return "Green";
                return string.Empty;
            }
        }
    }
    [GridAction]
    public ActionResult _List(int? Id)
    {
        List<ObjectDTO> ret = new List<ObjectDTO>();
        _db.GetObjectFromDB().ToList().ForEach(x =>
        {
            ret.Add(new ObjectDTO { ObjectFromDB = x } );
        });
    }
