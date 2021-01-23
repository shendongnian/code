    class ObjBEqualityComparer : IEqualityComparer<ObjB> {
        public bool Equals(ObjB x, ObjB y) {
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(ObjB o) {
            return o.Id.GetHashCode();
        }
    }
    var objBComparer = new ObjBEqualityComparer();
    var result = objAList.Select(o => o.ObjB).Distinct(objBComparer);
