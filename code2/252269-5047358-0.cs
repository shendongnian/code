    public IMyInterface GetObject(int id, string typeName) {
        switch(typeName) {
            case "Type1":
                return (IMyInterface)db.Type1s.SingleOrDefault(t => t.TypeID == id);
            case "Type2":
                return (IMyInterface)db.Type2.SingleOrDefault(t => t.TypeID == id);
            default:
                return null;
        }
    }
