    string s1 = "ani\u00ADmal";
    string s2 = "animal";
    string s3 = "abc";
    string s4 = "abc";
    string s5 = "ABC";
    
    bool b1 = s1.CompareTo(s2) > -1; // return true, exists
    bool b2 = s3.CompareTo(s4) > -1; // return true, exists
    bool b3 = s3.CompareTo(s5) > -1; // return false, no case sensitive, no exists
    
    bool b4 = s1.Contains(s2); // return false, no exists
    bool b5 = s3.Contains(s4); // return true, exists
    bool b6 = s3.Contains(s5); // return false, no case sensitive, no exists
            
    string s6 = "MACHINE";
    string s7 = "machine";
    string s8 = "nature";
    
    int a = String.Compare(s6, 0, s7, 0, s6.Length, true);  // return 0, contain and is less 
    int b = String.Compare(s6, 0, s7, 0, s6.Length, false); // return 1, contain and is greater
    int c = String.Compare(s6, 0, s8, 0, s6.Length, true);  // return -1, no contain
    int d = String.Compare(s6, 0, s8, 0, s6.Length, false);  // return -1, no contain
    
    int e = s1.IndexOfAny(s2.ToCharArray()); // return 0, exists
    int f = s3.IndexOfAny(s4.ToCharArray()); // return 0, exists
    int g = s3.IndexOfAny(s5.ToCharArray()); // return -1, no case sensitive, no exists
    
    int h = s1.IndexOf(s2); // return 0, exists
    int i = s3.IndexOf(s4); // return 0, exists
    int j = s3.IndexOf(s5); // return -1, no exists
