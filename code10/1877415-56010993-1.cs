public static int Compare( Vector3 v1, Vector3 v2 )
{
     // Comparing two vectors this way is fine
     // Unity has overloaded the == operator
     // So as to avoid floating point imprecision
     if( v1 == v2 ) return 0;
     if( Mathf.Approx( v1.y, v2.y ) )
     {
        float angle1 = Mathf.Acos( v1.x ) / v1.magnitude ;
        float angle2 = Mathf.Acos( v2.x ) / v2.magnitude ;
        if ( Mathf.Approx( angle1, angle2 ) ) return 0 ;
        return angle1 > angle2 ? 1 : -1;
     }
     return v1.y > v2.y ? 1 : -1;
}
Then, supposing you have a `List<Vector3>` , you can call `list.Sort( Compare )`
