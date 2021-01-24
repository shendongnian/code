enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }; 
static void Main(string[] args) {
    int d1 = (int)Days.Tue;  
    d1 = 33; // What does this mean?
    Days d2 = Days.Tue;
    d2 = 33; // Compilation error. Good.
}
\* = It's quite easy to make enum's value any int value, *if you really want to*.
