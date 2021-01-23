    public class TestComparerer : IEqualityComparer<Test> {
    	bool IEqualityComparer<Test>.Equals(Test a, Test b) {
    		return a!=null && b!=null && a.ID.Equals(b.ID);
    	}
    	int IEqualityComparer<Test>.GetHashCode(Test a){
    	 return a.ID.GetHashCode();
    	}
    }
    var query = list2.intersect(list1,new TestComparer());
