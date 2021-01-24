    public partial class HierarchyId_Operations  
    {  
        [SqlFunction(FillRowMethodName = "FillRow_ListAncestors")]
        public static IEnumerable ListAncestors(SqlHierarchyId h)
        {  
            while (!h.IsNull)  
            {  
                yield return (h);  
                h = h.GetAncestor(1);  
            }  
        }  
        public static void FillRow_ListAncestors(
            Object obj,
            out SqlHierarchyId ancestor
            )
        {  
            ancestor = (SqlHierarchyId)obj;  
        }  
      
        public static HierarchyId CommonAncestor(
            SqlHierarchyId h1,
            HierarchyId h2
            )  
        {  
            while (!h1.IsDescendantOf(h2))  
                h1 = h1.GetAncestor(1);  
      
            return h1;  
        }  
    }
