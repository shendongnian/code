enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }; 
static void Main(string[] args) {
    int weekday1 = (int)Days.Tue;  
    weeekday1 = 33; // What does this mean?
    Days weekday2 = Days.Tue;
    weekday2 = 33; // Compilation error. Good.
}
\* = It's quite easy to make enum's value any int value, *if you really want to*.
