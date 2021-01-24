c#
 public void OnGet()
 {
   string Person = Username("John");
 }
But you need to assign property `Person`:
c#
 public void OnGet()
 {
   Person = Username("John");
 }
