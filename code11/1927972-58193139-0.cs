using System;
public class Program {
    public DateTime MyDate1 { get => DateTime.UtcNow; }
    public DateTime MyDate2 => DateTime.UtcNow;
    public void Main() {
    }
}
the abbreviated IL for both versions is (I used https://sharplab.io):
    // Methods
    .method public hidebysig specialname 
        instance valuetype [mscorlib]System.DateTime get_MyDate1 () cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 6 (0x6)
        .maxstack 8
        IL_0000: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_UtcNow()
        IL_0005: ret
    } // end of method Program::get_MyDate1
    .method public hidebysig specialname 
        instance valuetype [mscorlib]System.DateTime get_MyDate2 () cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 6 (0x6)
        .maxstack 8
        IL_0000: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_UtcNow()
        IL_0005: ret
    } // end of method Program::get_MyDate2
(...)
// Properties
    .property instance valuetype [mscorlib]System.DateTime MyDate1()
    {
        .get instance valuetype [mscorlib]System.DateTime Program::get_MyDate1()
    }
    .property instance valuetype [mscorlib]System.DateTime MyDate2()
    {
        .get instance valuetype [mscorlib]System.DateTime Program::get_MyDate2()
    }
