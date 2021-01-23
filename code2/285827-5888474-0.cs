    public class VerticesType : IUserType
    {
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var retval = new List<Point>();
            var xCoords = ((string) NHibernateUtil.String.NullSafeGet(rs, names[0])).Split(",");
            var yCoords = ((string) NHibernateUtil.String.NullSafeGet(rs, names[1])).Split(",");
            for(i = 0; i < xCoords.Length; i++)
            {
                retval.Add(new Point(int.Parse(xCoords[i]), int.Parse(yCoords[i])));
            }
            return retval;
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var list = value as List<Point>;
            if( list == null )
            {
                NHibernateUtil>String.NullSafeSet(cmd, null, index);
                NHibernateUtil>String.NullSafeSet(cmd, null, index + 1);
                return;
            }
            NHibernateUtil.String.NullSafeSet(cmd, string.Join(",", list.Select(v => v.X.ToString()), index);
            NHibernateUtil.String.NullSafeSet(cmd, string.Join(",", list.Select(v => v.Y.ToString()), index + 1);
        }
        # rest of IUserType implementation here
    }
