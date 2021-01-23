    string s1 = null;
    int len = s1.Length; // s1 is null. There is no string to get a length from
    
    public class A1 {public int PA1 {get;set;}}
    public class B1 {public A1 RA1 {get;set;}}
    B1 b1 = new B1();
    int ia1 = b1.RA1.PA1; // You never initialized the RA1 property.
                          //  there is no A1 to get a PA1 from.
