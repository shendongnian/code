    public static bool operator ==(DbVector3 a, DbVector3 b)
    {
       return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }
    public static bool operator !=(DbVector3 a, DbVector3 b)
    {
       return !(a == b);
    }
