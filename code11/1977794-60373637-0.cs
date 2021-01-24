string errorMessage;
var valid = IsValid(out errorMessage);   
Or use 
var valid=IsValid(out var errorMessage);
The compiler *knows* that the variable is used as an `out` parameter and will get a value unless an exception is thrown. 
On the other hand, `IsValid` *has* to store a value in the out parameter, overwriting any initial value. The original value is never used, and so doesn't need to be assigned.
This won't compile :
public bool IsValid(out string errorMessage) {
   return true;
}
and return :
> CS0177 The out parameter 'errorMessage' must be assigned to before control leaves the current method
This will work  :
public bool IsValid(out string errorMessage) {
   errorMessage="";
   return true;
}
