    if (Vector3.Cross(o,t) == Vector3.zero)
    {
        // Handle colinear situation
    }
    else 
    {
        Vector3 oCopy = o;
        Vector3 tCopy = t;
  
        Vector3.OrthoNormalize(ref oCopy, ref tCopy);
        Vector3 v = tCopy; // unnecessary; just included to have a variable named v
        // Use v
    }
        
